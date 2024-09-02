using DoctorAppointmentBookingSystem.Data;
using DoctorAppointmentBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentBookingSystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        HMSEntities db = new HMSEntities();
        public ActionResult Index()
        {
            var lst = from u in db.Tbl_User
                      join r in db.Tbl_Role on u.RoleId equals r.Id
                      select new { Id = u.Id, LoginName = u.LoginName, UserName = u.UserName, Password = u.Password, RoleName = r.RoleName, RoleId = r.Id };

            List<RegisterModel> model = new List<RegisterModel>();
            foreach (var r in lst)
            {
                model.Add(new RegisterModel
                {
                    Id = r.Id,
                    LoginName = r.LoginName,
                    UserName = r.UserName,
                    Password = r.Password,
                    RoleId = r.RoleId,
                    RoleName = r.RoleName,
                });
            }

            return View(model);
        }

        public ActionResult Create() 
        {
            ViewBag.LstRole=db.Tbl_Role.ToList();
            return View();
        }

        public ActionResult Save(Tbl_User user)
        {
            Tbl_User item=new Tbl_User();
            item.Id = user.Id;
            item.LoginName = user.LoginName;
            item.UserName = user.UserName;
            item.Password =Common.Cryptography.Encrypt(user.Password);
            item.RoleId = user.RoleId;           
            db.Tbl_User.Add(item);
            db.SaveChanges();
            return Redirect("/Register");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.lstRole=db.Tbl_Role.ToList();
            var item = db.Tbl_User.Where(x => x.Id == id).FirstOrDefault();
            return View(item);
        }

        public ActionResult Update(int id,Tbl_User user)
        {

            var item = db.Tbl_User.Where(x => x.Id == id).FirstOrDefault();
            item.LoginName=user.LoginName;
            item.UserName=user.UserName;
            item.Password = user.Password;
            item.RoleId = user.RoleId;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Register");
        }

        public ActionResult Delete(int id)
        {
            var item = db.Tbl_User.Where(x => x.Id == id).FirstOrDefault();
            db.Tbl_User.Remove(item);
            db.SaveChanges();
            return Redirect("/Register");
        }
    }
}