using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData.Model = db.Product.Find(1);
            return View();
        }

        public ActionResult TempData1()
        {
            ViewData["T1"] = "Hello World 1";
            TempData["T2"] = "Hello World 2";
            Session["T3"] = "Hello World 3";

            return RedirectToAction("TempData2");
        }

        public ActionResult TempData2()
        {
            ViewBag.T1 = ViewData["T1"];
            ViewBag.T2 = TempData["T2"];
            ViewBag.T3 = Session["T3"];

            return View();
        }
        public ActionResult Sample1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sample1(string UserName , string Password)
        {

            return Content(UserName +":"+Password);
        }


        [HttpPost]
        public ActionResult Sample2(FormCollection form)
        {

            return Content(form["UserName"] + ":" + form["Password"]);
        }


        [HttpPost]
        public ActionResult Sample3(
            [Bind(Prefix="Test")]
            SampleViewModel item)
        {

            return Content(item.UserName + ":" + item.Password);
        }

        public ActionResult Complex1()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Complex1(SampleViewModel item1,SampleViewModel item2)
        {

            return Content(item1.UserName + ":" + item1.Password + "<br/>" + item2.UserName + ":" + item2.Password);
        }

        public ActionResult Complex2()
        {

            var data = from p in db.Client
                       select new SampleViewModel()
                       {
                           UserName = p.FirstName,
                           Password = p.LastName,
                           Age = 18
                       };

            return View(data.Take(10));
        }

        [HttpPost]
        public ActionResult Complex2(IList<SampleViewModel> item)
        {
            return Content("");
        }



        public ActionResult Complex3()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Complex3(SampleViewModel item)
        {

            var data = new SampleViewModel() { };

            if (TryUpdateModel<SampleViewModel>(data))
            {
                return RedirectToAction("Complex3");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Complex3");
            }
            else
            {
                ModelState.AddModelError("Test", "TestString");
            }
            return View(data);
        }

    }
}