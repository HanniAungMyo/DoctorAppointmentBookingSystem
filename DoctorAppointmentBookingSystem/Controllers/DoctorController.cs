using DoctorAppointmentBookingSystem.Data;
using DoctorAppointmentBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentBookingSystem.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        HMSEntities db=new HMSEntities();
        public ActionResult Index()
        {

            var lst = from d in db.Tbl_Doctor
                        join s in db.Tbl_Speciality on d.SpecialityId equals s.Id
                        select new {Id=d.Id,Name=d.Name,SpecialityId=s.Id,SpecialityName=s.Name,DoctorFee=d.DoctorFees};

            List<DoctorModel> lstDoctor = new List<DoctorModel>();
            foreach (var item in lst)
            {
                lstDoctor.Add(new DoctorModel()
                {
                     Id=item.Id,
                     Name=item.Name,
                     SpecialityId=item.SpecialityId,
                     SpecialityName=item.SpecialityName,
                     DoctorFees=Convert.ToInt32(item.DoctorFee),
                });
            }
            return View(lstDoctor);
        }

        public ActionResult Create() 
        { 
            ViewBag.lstSpeciality=db.Tbl_Speciality.ToList();
            ViewBag.lstNameType=db.Tbl_NameType.ToList();
            return View();
        }
        public ActionResult Save(Tbl_Doctor doctor)
        {
            Tbl_Doctor item=new Tbl_Doctor();
            item.Name=doctor.Name;
            item.SpecialityId=doctor.SpecialityId;
            item.DoctorFees=doctor.DoctorFees;
            db.Tbl_Doctor.Add(item);
            db.SaveChanges();
            return Redirect("/Doctor");
        }

        public ActionResult Edit(int id) 
        {
            ViewBag.lstSpeciality = db.Tbl_Speciality.ToList();
            var item =db.Tbl_Doctor.Find(id);
            return View(item);
        }

        public ActionResult Update(int id,Tbl_Doctor doctor)
        {
            var item = db.Tbl_Doctor.Find(id);
            item.Name=doctor.Name;
            item.SpecialityId = doctor.SpecialityId;
            item.DoctorFees = doctor.DoctorFees;
            db.Entry(item).State=EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Doctor");
        }

        public ActionResult Delete(int id)
        {
            var item = db.Tbl_Doctor.Where(x => x.Id == id).FirstOrDefault();
            db.Tbl_Doctor.Remove(item);
            db.SaveChanges();
            return Redirect("/Doctor");
        }

    }
}