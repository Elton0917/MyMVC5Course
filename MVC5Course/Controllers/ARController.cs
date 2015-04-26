using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View("View1");
        }
        public ActionResult View1()
        {
            return View();
        }

        public ActionResult Content1()
        {
            return Content("AA");
        }

        public ActionResult File1()
        {
            byte[] content = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/Pic1.png"));

            return File(content, "image/png");
        }

        public ActionResult File2()
        {
            return File(Server.MapPath("~/Content/Pic1.png"), "image/png");
        }

        public ActionResult File3(string url)
        {
            var wc = new WebClient();
            var content = wc.DownloadData(url);

            return File(content, "image/png");
        }

        public ActionResult File4()
        {
            return File(Server.MapPath("~/Content/File4.htm"), "text/html");
        }

        public ActionResult File5()
        {
            byte[] content = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/Pic1.png"));

            return File(content, "image/png", "File5.png");
        }

        public ActionResult JavaScript1()
        {
            return JavaScript("alert('JS')");
        }

        public ActionResult Json1()
        {
            db.Configuration.LazyLoadingEnabled= false;
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Product.Include(x=>x.OrderLine).Take(10);

            return Json(data,JsonRequestBehavior.AllowGet);
        }

         public ActionResult Redirect1()
        {
            return RedirectToAction("File3", new { url = "http://pixelbuddha.net/sites/default/files/freebie-slide/freebie-slide-1426497148-1.jpg" });
        }

        public ActionResult Redirect2()
        {
            return RedirectToActionPermanent("File3", new { url = "http://pixelbuddha.net/sites/default/files/freebie-slide/freebie-slide-1426497148-1.jpg" });
        }

        public ActionResult HttpNotFound1()
        {
            //return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return HttpNotFound();
        }

       public ActionResult HttpStatusCodeResult1()
       {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult HttpStatusCodeResult2()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

    }
}   