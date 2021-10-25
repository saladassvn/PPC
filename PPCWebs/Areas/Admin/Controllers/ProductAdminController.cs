using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCWebs.Models;

namespace PPCWebs.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        AD25Team21Entities model = new AD25Team21Entities();
        // GET: Admin/ProductAdmin
        public ActionResult Index()
        {
            var property = model.Properties.OrderByDescending(x => x.ID).ToList();
            return View(property);
        }
        //
        public ActionResult Detail()
        {
            var property = model.Properties.OrderByDescending(x => x.ID).ToList();
            return View(property);
        }
    }
}