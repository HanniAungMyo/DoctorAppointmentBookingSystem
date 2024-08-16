using DoctorAppointmentBookingSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentBookingSystem.Controllers
{
    public class NameTypeController : Controller
    {
        // GET: NameType
        HMSEntities db = new HMSEntities();
        public ActionResult Index()
        {
            var lst = db.Tbl_NameType.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Save(Tbl_NameType nameType) 
        {
            Tbl_NameType item = new Tbl_NameType();
            item.Type = nameType.Type;
            item.CreatedBy = 1;
            item.CreatedDate = DateTime.Now;
            db.Tbl_NameType.Add(item);
            db.SaveChanges();
            return Redirect("/NameType");
        }
        public ActionResult Edit(int id)
        {
            var item = db.Tbl_NameType.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        public ActionResult Update(int id,Tbl_NameType nameType)
        {
            var item = db.Tbl_NameType.Where(x => x.Id == id).FirstOrDefault();
            item.Type=nameType.Type;
            item.ModifiedDate =DateTime.Now;
            item.ModifiedBy = 1;
            db.Entry(item).State=EntityState.Modified;
            db.SaveChanges();
            return Redirect("/NameType");
        }
        public ActionResult Delete(int id)
        {
            var item = db.Tbl_NameType.Where(x => x.Id == id).FirstOrDefault();
            db.Tbl_NameType.Remove(item);
            db.SaveChanges();
            return Redirect("/NameType");
        }

    }
}