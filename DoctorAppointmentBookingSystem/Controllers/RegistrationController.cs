using DoctorAppointmentBookingSystem.Data;
using DoctorAppointmentBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentBookingSystem.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        HMSEntities db = new HMSEntities();

        public ActionResult Index()
        {
            var lst = from r in db.Tbl_Registration
                      join m in db.Tbl_MaritalStatus on r.MaritalStatusId equals m.Id
                      join n in db.Tbl_NameType on r.NameTypeId equals n.Id
                      select new { Id = r.Id, Name = r.Name, Dob = r.Dob, NameTypeId = n.Id, NameType = n.Type, MaritalStatusId = m.Id, MaritalStatusName = m.Name, PhoneNumber = r.PhoneNo, FatherName = r.FatherName, Gender = r.Gender };
            List<RegistrationModel> model = new List<RegistrationModel>();
            foreach (var item in lst)
            {
                model.Add(new RegistrationModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Dob = Convert.ToDateTime(item.Dob),
                    PhoneNo = item.PhoneNumber,
                    FatherName = item.FatherName,
                    Gender = item.Gender,
                    NamTypeId = item.NameTypeId,
                    NameType = item.NameType,
                    MaritalStatusId = item.MaritalStatusId,
                    MaritalStatusName = item.MaritalStatusName,
                });
            }
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.lstMaritalStatus = db.Tbl_MaritalStatus.ToList();
            ViewBag.lstNameType = db.Tbl_NameType.ToList();
            return View();
        }
        public ActionResult Save(Tbl_Registration reg)
        {
            Tbl_Registration item = new Tbl_Registration();
            item.Name = reg.Name;
            item.Dob = reg.Dob;
            item.PhoneNo = reg.PhoneNo;
            item.FatherName = reg.FatherName;
            item.Gender = reg.Gender;
            item.MaritalStatusId = reg.MaritalStatusId;
            item.NameTypeId = reg.NameTypeId;
            db.Tbl_Registration.Add(item);
            db.SaveChanges();
            return Redirect("/Registration");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.lstMaritalStatus = db.Tbl_MaritalStatus.ToList();
            ViewBag.lstNameType = db.Tbl_NameType.ToList();
            var item = db.Tbl_Registration.Find(id);
            return View(item);
        }
        public ActionResult Update(int id, Tbl_Registration reg)
        {
            var item = db.Tbl_Registration.Find(id);
            item.Name = reg.Name;
            item.Dob = reg.Dob;
            item.PhoneNo = reg.PhoneNo;
            item.FatherName = reg.FatherName;
            item.Gender = reg.Gender;
            item.NameTypeId = reg.NameTypeId;
            item.MaritalStatusId = reg.MaritalStatusId;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Registration");
        }
        public ActionResult Delete(int id)
        {
            var item = db.Tbl_Registration.Where(x => x.Id == id).FirstOrDefault();
            db.Tbl_Registration.Remove(item);
            db.SaveChanges();
            return Redirect("/Registration");
        }

    }
}
