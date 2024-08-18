using DoctorAppointmentBookingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace DoctorAppointmentBookingSystem.Controllers
{
    public class SpecialityController : Controller
    {
        // GET: Speciality
        HMSEntities db = new HMSEntities();
        public ActionResult Index()
        {
            var lst = db.Tbl_Speciality.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Save(Tbl_Speciality speciality)
        {
            Tbl_Speciality item = new Tbl_Speciality();
            item.Name = speciality.Name;
            item.CreatedBy = 1;
            item.CreatedDate = DateTime.Now;
            db.Tbl_Speciality.Add(item);
            db.SaveChanges();
            return Redirect("/Speciality");
        }
        public ActionResult Edit(int id)
        {
            var item = db.Tbl_Speciality.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }
        public ActionResult Update(int id,Tbl_Speciality speciality)
        {
            var item = db.Tbl_Speciality.Where(x => x.Id == id).FirstOrDefault();
            item.Id=speciality.Id;
            item.Name=speciality.Name;
            item.ModifiedDate=DateTime.Now;
            item.ModifiedBy = 1;
            db.Entry(item).State=EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Speciality");
        }
        public ActionResult Delete(int id)
        {
            var item=db.Tbl_Speciality.Where(x =>x.Id==id).FirstOrDefault();
            db.Tbl_Speciality.Remove(item);
            db.SaveChanges();
            return Redirect("/Speciality");
        }
    }
}