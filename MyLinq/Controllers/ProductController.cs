using MyLinq.MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLinq.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductIndex()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();//E-Linq ile db tanımlama
            var list = db.Products.ToList();//EF linq ile list yapmak
            var list2 = db.Products.Where(k => k.UnitPrice == 15).ToList();

            return View(list);
        }

        [HttpGet]//Page Load=> readonly
        public ActionResult ProductUpdate(int id)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirUrun = db.Products.Where(p => p.ProductID == id).FirstOrDefault();

            return View(getirUrun);

        }

        [HttpPost]//Page post olurken HttpPost işlemi olmalı=> post edit tir, Remove, Edit, Insert
        public ActionResult ProductUpdate(Products products)
        {
            //EF-linq ile datase den veri güncellemek
            NORTHWNDEntities db = new NORTHWNDEntities();
            var getirUrun = db.Products.Where(p => p.ProductID == products.ProductID).FirstOrDefault();

            getirUrun.ProductName = products.ProductName;
            //getirUrun.CategoryID = products.CategoryID;
            getirUrun.CategoryID = 2;
            getirUrun.SupplierID = 1;
            getirUrun.UnitsInStock = products.UnitsInStock;

            db.SaveChanges();

            return View();
        }


        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
    }
}