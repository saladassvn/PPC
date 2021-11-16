using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using PPCWebs.Models;
namespace PPCWebs.Areas.Admin.Controllers
{
    public class FullContractController : Controller
    {
        private AD25Team21Entities db = new AD25Team21Entities();
        // GET: Admin/FullContract
        public ActionResult Index()
        {
            var fullContract = db.FullContracts.Include(fc => fc.Customer).Include(fc => fc.Property);
            return View(fullContract.OrderByDescending(x => x.ID).ToList());
        }

        public ActionResult searchInstallmentContract(string searching)
        {
            return View(db.FullContracts.Where(x => x.Property.PropertyName.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Print(int? id)
        {
            var printData = db.FullContracts.FirstOrDefault(x => x.ID == id);
           
            return View(printData);
        }
    }
}