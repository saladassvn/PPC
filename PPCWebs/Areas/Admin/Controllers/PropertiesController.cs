using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPCWebs.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PPCWebs.Areas.Admin.Controllers
{
    public class PropertiesController : Controller
    {
        private AD25Team21Entities db = new AD25Team21Entities();

        // GET: Admin/Properties
        public ActionResult Index()
        {
            var properties = db.Properties.Include(p => p.District).Include(p => p.PropertyStatu).Include(p => p.PropertyType);
            return View(properties.OrderByDescending(x => x.ID).ToList());
        }

        // GET: Admin/Properties/Details/5
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

        // GET: Admin/Properties/Create
        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "DistrictName");
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatus, "ID", "PropertyStatusName");
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "PropertyTypeName");
            return View();
        }

        // POST: Admin/Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PropertyCode,PropertyName,PropertyTypeID,Description,DistrictID,Address,Area,BedRoom,BathRoom,Price,InstallmentRate,Avatar,Album,PropertyStatusID")] Property property, HttpPostedFileBase img)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (img != null)
                    {
                        string fileName = System.IO.Path.GetFileName(img.FileName);
                        string filePath = "~/Images/" + fileName;
                        Console.WriteLine(filePath);
                        img.SaveAs(Server.MapPath(filePath));
                        db.Properties.Add(new Property
                        {
                            PropertyCode = property.PropertyCode,
                            PropertyName = property.PropertyName,
                            PropertyTypeID = property.PropertyTypeID,
                            Description = property.Description,
                            DistrictID = property.DistrictID,
                            Address = property.Address,
                            Area = property.Area,
                            BedRoom = property.BedRoom,
                            BathRoom = property.BathRoom,
                            Price = property.Price,
                            InstallmentRate = property.InstallmentRate,
                            PropertyStatusID = property.PropertyStatusID,
                            Avatar = filePath
                        }) ;
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {

                }
            }

            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "DistrictName", property.DistrictID);
            ViewBag.PropertyStatusID = new SelectList(db.PropertyStatus, "ID", "PropertyStatusName", property.PropertyStatusID);
            ViewBag.PropertyTypeID = new SelectList(db.PropertyTypes, "ID", "PropertyTypeName", property.PropertyTypeID);
            return View(property);
        }

        // GET: Admin/Properties/Edit/5
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

        // POST: Admin/Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Admin/Properties/Delete/5
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

        // POST: Admin/Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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
