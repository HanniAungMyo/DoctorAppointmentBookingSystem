using DoctorAppointmentBookingSystem.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentBookingSystem.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        HMSEntities db=new HMSEntities();
        public ActionResult Index()
        {

            var lst=db.Tbl_Role.ToList();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Save(Tbl_Role role)
        {
            Tbl_Role item= new Tbl_Role();
            item.Id = role.Id;
            item.RoleName = role.RoleName;
            return Redirect("/Role");
        }

        public ActionResult Edit(int id) 
        {
            var item = db.Tbl_Role.Where(x => x.Id == id).FirstOrDefault();
            return View(item);  
        }

        public ActionResult Update(int id,Tbl_Role role)
        {
            var item = db.Tbl_Role.Where(x => x.Id == id).FirstOrDefault();
            item.RoleName = role.RoleName;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Role");
        }
        public ActionResult Delete(int id) 
        {
            var item = db.Tbl_Role.Where(x => x.Id == id).FirstOrDefault();
            db.Tbl_Role.Remove(item);
            db.SaveChanges();
            return Redirect("/Role");
        }
    }
}