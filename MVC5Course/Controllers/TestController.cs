﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}