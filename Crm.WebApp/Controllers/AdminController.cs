using Crm.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm.WebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            Crm.BusinessLayer.Test test = new Test();
            
            return View();
        }
    }
}