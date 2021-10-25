using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCWebs.Models;

namespace PPCWebs.Areas.Admin.Controllers
{
    public class AddPropertyController : Controller
    {
        AD25Team21Entities model = new AD25Team21Entities();
        // GET: Admin/AddProperty
        public ActionResult Index()
        {
            return View();
        }
       
    }
}