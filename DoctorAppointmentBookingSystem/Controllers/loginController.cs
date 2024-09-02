using DoctorAppointmentBookingSystem.Data;
using DoctorAppointmentBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorAppointmentBookingSystem.Controllers
{
    public class loginController : Controller
    {
        HMSEntities db = new HMSEntities();
        // GET: login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin(Tbl_User user)
        {
            ResultMessage msg = new ResultMessage();
            var item = db.Tbl_User.Where(x => x.LoginName == user.LoginName).FirstOrDefault();
            var _password= Common.Cryptography.Encrypt(user.Password);
            if (item != null)
            {
                if (item.Password == Common.Cryptography.Encrypt(user.Password))
                {
                    msg.respMessage = "Login Successfully";
                    msg.respCode = "000";
                    msg.respType = "Success";
                    Session["userName"]=item.UserName;
                    return Redirect("/Home");

                }
                else
                {
                    msg.respMessage = "Login Name And Password are Invalid";
                    msg.respCode = "111";
                    msg.respType = "Warning";
                }
            }
            else
            {
                msg.respMessage = "Login Name And Password are Invalid";
                msg.respCode = "111";
                msg.respType = "Warning";
            }
            return Redirect("/Login");
        }
    }
}