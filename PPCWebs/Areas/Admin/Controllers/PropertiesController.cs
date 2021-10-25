using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPCWebs.Models;

namespace PPCWebs.Areas.Admin.Controllers
{
    public class PropertiesController : Controller
    {
        private AD25Team21Entities db = new AD25Team21Entities();

        public ActionResult Index()
        {
            var properties = db.Properties.Include(p => p.District).Include(p => p.PropertyStatu).Include(p => p.PropertyType);
            return View(properties.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "DistrictName");
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatus, "ID", "PropertyStatusName");
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "PropertyTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PropertyCode,PropertyName,PropertyTypeID,Description,DistrictID,Address,Area,BedRoom,BathRoom,Price,InstallmentRate,Avatar,Album,PropertyStatusID")] Property property, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ImagePath != null)
                    {
                        String filename = System.IO.Path.GetFileName(ImagePath.FileName);
                        String filePath = "~/Images/" + filename;
                        ImagePath.SaveAs(Server.MapPath(filePath));
                        db.Properties.Add(new Property
                        {
                            PropertyName = property.PropertyName,
                            PropertyTypeID = property.PropertyTypeID,
                            Address = property.Address,
                            DistrictID = property.DistrictID,
                            Area = property.Area,
                            BedRoom = property.BedRoom,
                            BathRoom = property.BathRoom,
                            Price = property.Price,
                            InstallmentRate = property.InstallmentRate,
                            PropertyStatusID = property.PropertyStatusID,
                            Avatar = filename,
                            Album = filename,
                            Description = property.Description
                        });           
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        db.Properties.Add(property);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {
                }
                ///
            }

            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "DistrictName", property.DistrictID);
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatus, "ID", "PropertyStatusName", property.PropertyStatusID);
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "PropertyTypeName", property.PropertyTypeID);
            return View(property);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "DistrictName", property.DistrictID);
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatus, "ID", "PropertyStatusName", property.PropertyStatusID);
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "PropertyTypeName", property.PropertyTypeID);
            return View(property);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,PropertyCode,PropertyName,PropertyTypeID,Description,DistrictID,Address,Area,BedRoom,BathRoom,Price,InstallmentRate,Avatar,Album,PropertyStatusID")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "DistrictName", property.DistrictID);
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatus, "ID", "PropertyStatusName", property.PropertyStatusID);
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "PropertyTypeName", property.PropertyTypeID);
            return View(property);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
