using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        //FabricsEntities db = new FabricsEntities();
        //ProductRepository repo = RepositoryHelper.GetProductRepository();
        // GET: Test
        public ActionResult Index()
        {
            //var data = from p in db.Product
            //           where p.IsDelete == false
            //           select p;

            //var repo = new ProductRepository();
            //repo.UnitOfWork = new EFUnitOfWork();

            //var data = repo.All().Where(p => p.IsDelete == false);
            var data = repo.Get取得所有尚未刪除的商品資料Top10();

            //return View(data.Take(10));
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        //打mvcp 按tab兩下
        [HttpPost]
        public ActionResult Create(Product data)
        {
            if(ModelState.IsValid)
            {
                //db.Product.Add(data);
                //db.SaveChanges();

                repo.Add(data);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            //var item = db.Product.Find(id);
            var item =repo.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Product data, int id)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(data).State = EntityState.Modified;
                //db.SaveChanges();

                //var item = db.Product.Find(id);
                var item = repo.Find(id);

                item.ProductName = data.ProductName;
                item.Price = data.Price;
                item.Stock = data.Stock;
                item.Active = data.Active;
                repo.UnitOfWork.Commit();

                TempData["ProductItem"] = item;

                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Details(int id)
        {
            //var item = db.Product.Find(id);
            var item = repo.Find(id);
            return View(item);
        }


        public ActionResult Delete(int id)
        {
            
                //var item = db.Product.Find(id);
                var item = repo.Find(id);

                //db.OrderLine.RemoveRange(item.OrderLine.ToList());
                //db.Product.Remove(item);

                item.IsDelete = true;

            //db.SaveChanges();
            repo.UnitOfWork.Commit();

            return RedirectToAction("Index");

        }
    }
}