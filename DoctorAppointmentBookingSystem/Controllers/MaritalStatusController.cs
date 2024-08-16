using DoctorAppointmentBookingSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentBookingSystem.Controllers
{
    public class MaritalStatusController : Controller
    {
        // GET: MaritalStatus
        HMSEntities db=new HMSEntities();
        public ActionResult Index()
        {
            var lst =  db.Tbl_MaritalStatus.ToList();
            return View(lst);
        }
        public ActionResult Create() 
        {
            return View();  
        }
        public ActionResult Save(Tbl_MaritalStatus maritalStatus)
        {
            Tbl_MaritalStatus item = new Tbl_MaritalStatus();
            item.Name = maritalStatus.Name;
            item.CreatedBy = 1;
            item.CreatedDate = DateTime.Now;
            db.Tbl_MaritalStatus.Add(item);
            db.SaveChanges();
            return Redirect("/MaritalStatus");
        }
        public ActionResult Edit(int id)
        {
            var item = db.Tbl_MaritalStatus.Where(x=>x.Id==id).FirstOrDefault();
            return View(item);
        }
        public ActionResult Update(int id,Tbl_MaritalStatus maritalStatus)
        {
            var item = db.Tbl_MaritalStatus.Where(x => x.Id == id).FirstOrDefault();
            item.Name= maritalStatus.Name;
            item.ModifiedDate = DateTime.Now;
            item.ModifiedBy = 1;
            db.Entry(item).State= EntityState.Modified;
            db.SaveChanges();
            return Redirect("/MaritalStatus");
        }
        public ActionResult Delete(int id)
        {
            var item = db.Tbl_MaritalStatus.Where(x => x.Id == id).FirstOrDefault();
            db.Tbl_MaritalStatus.Remove(item);
            db.SaveChanges();
            return Redirect("/MaritalStatus");
        }
    }
}