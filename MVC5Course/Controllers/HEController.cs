using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HEController : Controller
    {
        // GET: HE
        public ActionResult Index()
        {
            return View();
        }

        [HandleError(Master="",ExceptionType=typeof(ArgumentException), View="Error.Argument")]
        public ActionResult MakeError(string type ="")
        {
            if (type == "1")
            {
                throw new ArgumentException("Test Argument");
            }
            else
            {
                throw new Exception("Test Ex");
            }
        }
    }
}