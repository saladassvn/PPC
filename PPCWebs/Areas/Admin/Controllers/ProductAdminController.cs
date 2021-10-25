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

        public ActionResult Create()
        {
            
            ViewBag.PropertyTypeID = model.PropertyTypes.OrderByDescending(x => x.ID).ToList();
            ViewBag.DistrictID = model.Districts.OrderByDescending(x => x.ID).ToList();
            ViewBag.PropertyStatusID = model.PropertyStatus.OrderByDescending(x => x.ID).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Property p)
        {
            var property = new Property();
            property.PropertyName = p.PropertyName;
            property.PropertyTypeID = p.PropertyTypeID;
            property.Address = p.Address;
            property.DistrictID = p.DistrictID;
            property.Area = p.Area;
            property.BedRoom = p.BedRoom;
            property.BathRoom = p.BathRoom;
            property.Price = p.Price;
            property.InstallmentRate = p.InstallmentRate;
            property.PropertyStatusID = p.PropertyStatusID;
            property.Avatar = p.Avatar;
            property.Album = p.Album;
            property.Description = p.Description;
            model.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}