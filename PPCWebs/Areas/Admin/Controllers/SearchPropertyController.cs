using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCWebs.Models;

namespace PPCWebs.Areas.Admin.Controllers
{
    public class SearchPropertyController : Controller
    {
        // GET: Admin/SearchProperty
        AD25Team21Entities db = new AD25Team21Entities();
        public ActionResult Index(string searching)
        {
            return View(db.Properties.Where(x => x.PropertyName.Contains(searching) || searching == null).ToList());
        }
    }
}