namespace Bar.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bar.Models.BarEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.BarEntities context)
        {
            if (!(context.AspNetUsers.Any(u => u.UserName == "rory"))) {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "rory", Email = "roryaherne@gmail.com" };
                userManager.Create(userToInsert, "Hunter12!");
            }

            AspNetUser user = context.AspNetUsers.First();

            context.Places.AddOrUpdate(
                p => p.Title,
                new Place { Title = "Table 1", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 },
                new Place { Title = "Table 2", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 4 },
                new Place { Title = "Table 3", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 4 },
                new Place { Title = "Table 4", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 },
                new Place { Title = "Table 5", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 6 },
                new Place { Title = "Table 6", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 10 },
                new Place { Title = "Table 7", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 9 },
                new Place { Title = "Table 8", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 8 },
                new Place { Title = "Table 9", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 3 },
                new Place { Title = "Table 10", CreatedById = user.Id, DateCreated = DateTime.Now, Capacity = 2 }
            );

            context.ProductTypes.AddOrUpdate(p => p.Title,

                new ProductType { Title = "Bier", Description = "Bier ist super!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Wein", Description = "Wein ist geil!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Cocktail", Description = "F�r Frauen!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Whiskey", Description = "Whiskey ist super!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Lik�r", Description = "Lik�r ist gef�hrlich!", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductType { Title = "Limonade", Description = "S��", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            var bierCatId = context.ProductTypes.Where(t => t.Title == "Bier").Select(t => t.ProductTypeId).FirstOrDefault();

            context.OrderStates.AddOrUpdate(o => o.Title,

                new OrderState { Title = "Ordered", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now },
                new OrderState { Title = "Delivered", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now },
                new OrderState { Title = "Paid", Description = "Ordered", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            context.ProductStates.AddOrUpdate(p => p.Title,

                new ProductState { Title = "Active", Description = "Active", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductState { Title = "Inactive", Description = "Inactive", CreatedById = user.Id, DateCreated = DateTime.Now },
                new ProductState { Title = "Expired", Description = "Expired", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            int activeProductId = context.ProductStates.Where(s => s.Title == "Active").Select(s => s.ProductStateId).FirstOrDefault();

            context.Units.AddOrUpdate(u => u.Title,
                new Unit { Title = "Milliliter", BaseFactor = 1, ShortTitle = "ml", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Liter", BaseFactor = 1000, ShortTitle = "L", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Centiliter", BaseFactor = 10, ShortTitle = "cl", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Gro�", BaseFactor = 500, ShortTitle = "0.5L", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Klein", BaseFactor = 300, ShortTitle = "0.3L", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Pfiff", BaseFactor = 200, ShortTitle = "0.2L", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Achtel", BaseFactor = 125, ShortTitle = "1/8", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Viertel", BaseFactor = 250, ShortTitle = "1/4", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Fass", BaseFactor = 80000, ShortTitle = "Fass", CreatedById = user.Id, DateCreated = DateTime.Now },
                new Unit { Title = "Gro�e Flasche", BaseFactor = 500, ShortTitle = "0.5 Fl", CreatedById = user.Id, DateCreated = DateTime.Now }
            );

            int ml = context.Units.Where(u => u.Title == "ml").Select(u => u.UnitId).FirstOrDefault();
            int gross = context.Units.Where(u => u.Title == "0.5L").Select(u => u.UnitId).FirstOrDefault();
            int klein = context.Units.Where(u => u.Title == "0.3L").Select(u => u.UnitId).FirstOrDefault();
            int viertel = context.Units.Where(u => u.Title == "1/4").Select(u => u.UnitId).FirstOrDefault();
            int keg = context.Units.Where(u => u.Title == "Fass").Select(u => u.UnitId).FirstOrDefault();
            int gFlasche = context.Units.Where(u => u.Title == "0.5 Fl").Select(u => u.UnitId).FirstOrDefault();
            List<int> beerServings = new List<int>();
            beerServings.Add(gross);
            beerServings.Add(klein);

            context.SaveChanges();

            Product guinness = new Product {
                Title = "Guinness",
                Description = "Ein mild trochene Stout aus Dublin",
                CreatedById = user.Id,
                DateCreated = DateTime.Now,
                ExperationPeriod = 30,
                ProductTypeId = bierCatId,
                ProductStateId = activeProductId,
                StockUnitId = keg,
                Units = context.Units.Where(u => beerServings.Contains(u.UnitId)).ToList()
            };

            Product marzen = new Product {
                Title = "Zipfer M�rzen",
                Description = "In Marz gebraut, in September fertig",
                CreatedById = user.Id,
                DateCreated = DateTime.Now,
                ExperationPeriod = 30,
                ProductTypeId = bierCatId,
                ProductStateId = activeProductId,
                StockUnitId = gFlasche,
                Units = context.Units.Where(u => u.UnitId == gFlasche).ToList()
            };

            Product zipfer = new Product {
                Title = "Zipfer",
                Description = "Standard Zipefer Bier",
                CreatedById = user.Id,
                DateCreated = DateTime.Now,
                ExperationPeriod = 30,
                ProductTypeId = bierCatId,
                ProductStateId = activeProductId,
                StockUnitId = keg,
                Units = context.Units.Where(u => beerServings.Contains(u.UnitId)).ToList()
            };

            context.Products.AddOrUpdate(p => p.Title, guinness, marzen, zipfer);

            context.SaveChanges();

            context.Orders.AddOrUpdate(o => o.Amount,
                new Order {
                    Amount = 2,
                    CreatedById = user.Id,
                    OrderStateId = context.OrderStates.Where(s => s.Description == "Ordered").Select(s => s.OrderStateId).FirstOrDefault(),
                    OrderTime = DateTime.Now,
                    PlaceId = context.Places.Where(p => p.Title == "Table 6").Select(p => p.PlaceId).FirstOrDefault(),
                    ProductId = guinness.ProductId,
                    UnitId = gross,
                    Price = 4.50
                },
                new Order {
                    Amount = 1,
                    CreatedById = user.Id,
                    OrderStateId = context.OrderStates.Where(s => s.Description == "Ordered").Select(s => s.OrderStateId).FirstOrDefault(),
                    OrderTime = DateTime.Now,
                    PlaceId = context.Places.Where(p => p.Title == "Table 6").Select(p => p.PlaceId).FirstOrDefault(),
                    ProductId = zipfer.ProductId,
                    UnitId = klein,
                    Price = 3.00
                }
                );

            context.SaveChanges();
        }
    }
}
