using MyLinq.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLinq.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryIndex()
        {

            NORTHWNDEntities db = new NORTHWNDEntities();
            var list = db.Categories.ToList();

            return View(list);
        }
        [HttpGet]

        public ActionResult CategoryUpdate(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirCategory = db.Categories.Where(p => p.CategoryID == id).FirstOrDefault();

            return View(getirCategory);

        }

        [HttpPost]//post işlemleri; edit,remove,insert...
        public ActionResult CategoryUpdate(Categories categories)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirCategory = db.Categories.Where(p => p.CategoryID ==categories.CategoryID).FirstOrDefault();
            getirCategory.CategoryName=categories.CategoryName;

            getirCategory.Description = categories.Description;


            db.SaveChanges();
            return View();

        }

    }
}