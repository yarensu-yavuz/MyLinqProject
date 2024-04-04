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
        #region CategoryList
        // GET: Category
        public ActionResult CategoryIndex()
        {

            NORTHWNDEntities db = new NORTHWNDEntities();
            var list = db.Categories.ToList();

            return View(list);
        }
        #endregion


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
            try
            {
                NORTHWNDEntities db = new NORTHWNDEntities();
                var getirCategory = db.Categories.Where(p => p.CategoryID == categories.CategoryID).FirstOrDefault();
                getirCategory.CategoryName = categories.CategoryName;
                getirCategory.Picture = getirCategory.Picture;
                getirCategory.Description = categories.Description;

                int saveResult = db.SaveChanges();
                //bavereges-deneme
                if (saveResult > 0)
                {
                    ViewBag.saveMessage = "Kategori başarılı bir şekilde güncellendi";
                    return View();
                }
                else
                {
                    ViewBag.saveMessage = "Kategori güncelleme işlemi başarısız oldu";
                    ViewData["mesaj"] = "deneme";
                    TempData["enBuyukData"] = getirCategory;
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.saveMessage = "Kategori güncelleme esnasında bir hata oluştu\nHATA:" + ex.Message;

                return View();
            }



        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirCategory = db.Categories.Where(p => p.CategoryID == id).FirstOrDefault();

            return View(getirCategory);
        }

        [HttpPost]
        public ActionResult Delete(Categories categories)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirCategory = db.Categories.Where(p => p.CategoryID ==categories.CategoryID).FirstOrDefault();
             db.Categories.Remove(getirCategory);

            int result = db.SaveChanges();
            if (result>0)
            {

            }

            return View(getirCategory);
        }

        [HttpPost]
        public ActionResult CategoryDelete(int categoryId,string categoryName)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirCategory = db.Categories.Where(p => p.CategoryID == categoryId).FirstOrDefault();
            db.Categories.Remove(getirCategory);

            int result = db.SaveChanges();
            if (result > 0)
            {

            }

            return View(getirCategory);
        }
    }
}