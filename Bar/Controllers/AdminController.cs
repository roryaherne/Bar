using Bar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bar.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private BarEntities db = new BarEntities();
        // GET: Admin
        public ActionResult Index()
        {
            AdminViewModel model = new AdminViewModel();
            var propList = model.GetType().GetProperties();
            foreach (var listProp in propList) {
                var prop = listProp.GetType();
                var x = prop.Name;
            }
            return View(model);
        }
    }
}