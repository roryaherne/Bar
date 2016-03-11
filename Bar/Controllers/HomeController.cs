using Bar.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bar.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            //Seed(new BarEntities() );
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void Seed(Models.BarEntities context) {
            if (!(context.AspNetUsers.Any(u => u.UserName == "rory"))) {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var userToInsert = new ApplicationUser { UserName = "rory", Email = "roryaherne@gmail.com" };
                userManager.Create(userToInsert, "Hunter12!");
            }

            AspNetUser user = context.AspNetUsers.First();

            context.Places.AddOrUpdate(
                p => p.Title,
                new Place { Title = "Table 1", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 2 },
                new Place { Title = "Table 2", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 4 },
                new Place { Title = "Table 3", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 4 },
                new Place { Title = "Table 4", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 2 },
                new Place { Title = "Table 5", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 6 },
                new Place { Title = "Table 6", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 10 },
                new Place { Title = "Table 7", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 9 },
                new Place { Title = "Table 8", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 8 },
                new Place { Title = "Table 9", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 3 },
                new Place { Title = "Table 10", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now, Capacity = 2 }
            );

            context.ProductTypes.AddOrUpdate(p => p.Title,

                new ProductType { Title = "Bier", Description = "Bier ist super!", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new ProductType { Title = "Wein", Description = "Wein ist geil!", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new ProductType { Title = "Cocktail", Description = "Für Frauen!", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new ProductType { Title = "Whiskey", Description = "Whiskey ist super!", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new ProductType { Title = "Likör", Description = "Likör ist gefährlich!", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new ProductType { Title = "Limonade", Description = "Süß", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            );

            var bierCatId = context.ProductTypes.Where(t => t.Title == "Bier").Select(t => t.ProductTypeId).FirstOrDefault();

            context.OrderStates.AddOrUpdate(o => o.Title,

                new OrderState { Title = "Ordered", Description = "Ordered", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new OrderState { Title = "Delivered", Description = "Ordered", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new OrderState { Title = "Paid", Description = "Ordered", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            );

            context.ProductStates.AddOrUpdate(p => p.Title,

                new ProductState { Title = "Active", Description = "Active", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new ProductState { Title = "Inactive", Description = "Inactive", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new ProductState { Title = "Expired", Description = "Expired", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            );

            int activeProductId = context.ProductStates.Where(s => s.Title == "Active").Select(s => s.ProductStateId).FirstOrDefault();

            context.Units.AddOrUpdate(u => u.Title,
                new Unit { Title = "Milliliter", BaseFactor = 1, ShortTitle = "ml", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Liter", BaseFactor = 1000, ShortTitle = "L", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Centiliter", BaseFactor = 10, ShortTitle = "cl", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Groß", BaseFactor = 500, ShortTitle = "0.5L", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Klein", BaseFactor = 300, ShortTitle = "0.3L", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Pfiff", BaseFactor = 200, ShortTitle = "0.2L", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Achtel", BaseFactor = 125, ShortTitle = "1/8", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Viertel", BaseFactor = 250, ShortTitle = "1/4", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Fass", BaseFactor = 80000, ShortTitle = "Fass", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Unit { Title = "Große Flasche", BaseFactor = 500, ShortTitle = "0.5 Fl", CreatedById = user.Id, ModifiedById = user.Id, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            );

            int ml = context.Units.Where(u => u.ShortTitle == "ml").Select(u => u.UnitId).FirstOrDefault();
            int gross = context.Units.Where(u => u.ShortTitle == "0.5L").Select(u => u.UnitId).FirstOrDefault();
            int klein = context.Units.Where(u => u.ShortTitle == "0.3L").Select(u => u.UnitId).FirstOrDefault();
            int viertel = context.Units.Where(u => u.ShortTitle == "1/4").Select(u => u.UnitId).FirstOrDefault();
            int keg = context.Units.Where(u => u.ShortTitle == "Fass").Select(u => u.UnitId).FirstOrDefault();
            int gFlasche = context.Units.Where(u => u.ShortTitle == "0.5 Fl").FirstOrDefault().UnitId;
            List<int> beerServings = new List<int>();
            beerServings.Add(gross);
            beerServings.Add(klein);

            context.SaveChanges();

            Product guinness = new Product {
                Title = "Guinness",
                Description = "Ein mild trochene Stout aus Dublin",
                CreatedById = user.Id, ModifiedById = user.Id,
                DateCreated = DateTime.Now, DateModified = DateTime.Now,
                ExperationPeriod = 30,
                ProductTypeId = bierCatId,
                ProductStateId = activeProductId,
                StockUnitId = keg,
                Units = context.Units.Where(u => beerServings.Contains(u.UnitId)).ToList()
            };

            Product marzen = new Product {
                Title = "Zipfer Märzen",
                Description = "In Marz gebraut, in September fertig",
                CreatedById = user.Id, ModifiedById = user.Id,
                DateCreated = DateTime.Now, DateModified = DateTime.Now,
                ExperationPeriod = 30,
                ProductTypeId = bierCatId,
                ProductStateId = activeProductId,
                StockUnitId = gFlasche,
                Units = context.Units.Where(u => u.UnitId == gFlasche).ToList()
            };

            Product zipfer = new Product {
                Title = "Zipfer",
                Description = "Standard Zipefer Bier",
                CreatedById = user.Id, ModifiedById = user.Id,
                DateCreated = DateTime.Now, DateModified = DateTime.Now,
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
                    CreatedById = user.Id, ModifiedById = user.Id,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    OrderStateId = context.OrderStates.Where(s => s.Description == "Ordered").Select(s => s.OrderStateId).FirstOrDefault(),
                    OrderTime = DateTime.Now,
                    PlaceId = context.Places.Where(p => p.Title == "Table 6").Select(p => p.PlaceId).FirstOrDefault(),
                    ProductId = guinness.ProductId,
                    UnitId = gross,
                    Price = 4.50
                },
                new Order {
                    Amount = 1,
                    CreatedById = user.Id, ModifiedById = user.Id,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
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