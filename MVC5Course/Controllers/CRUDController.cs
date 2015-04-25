using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class CRUDController : BaseController
    {
      

        // GET: CRUD
        public ActionResult Index(string keyword, int limit = 10)
        {
            //var data = db.Product.AsQueryable();

            //if (!String.IsNullOrEmpty(keyword))
            //{
            //    data = data.Where(p => p.ProductName.StartsWith(keyword));
            //}

            //data = data.Take(limit);

            //var data = db.Database.SqlQuery<Product>("SELECT TOP " + limit + " * FROM dbo.Product WHERE ProductName like @p0", keyword + "%").AsQueryable();

            var data = db.QueryProduct().AsQueryable();

            ViewBag.keyword = keyword;

            return View(data);
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            //Product p = db.Product.Find(id);
            //Product p = db.Product.Where(x => x.ProductId == id);
            Product p = db.Product.First(x => x.ProductId == id);

            return View(p);
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Product prod = new Product();

                prod.ProductName = collection["ProductName"];
                prod.Price = Convert.ToDecimal(collection["Price"]);
                prod.Stock = Convert.ToDecimal(collection["Stock"]);
                prod.Active = true;

                db.Product.Add(prod);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BatchUpdate()
        {
            var data = db.Product.Where(p => p.ProductName.StartsWith("C"));

            foreach (var item in data)
            {
                item.Price = item.Price * 2;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }


        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            var client = db.Client.Find(id);

            //var orders = db.Order.Where(p => p.ClientId == id);
            //var orders = client.Order.ToList();

            //foreach (var item in orders)
            //{
            //    db.Order.Remove(item);
            //}

            //db.Order.RemoveRange(orders);

            //db.Order.RemoveRange(client.Order.ToList());


            foreach (var order in client.Order.ToList())
            {
                db.OrderLine.RemoveRange(order.OrderLine);
            }

            db.Order.RemoveRange(client.Order.ToList());

            db.Client.Remove(client);

            db.SaveChanges();


            return RedirectToAction("Index", "Clients");
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
