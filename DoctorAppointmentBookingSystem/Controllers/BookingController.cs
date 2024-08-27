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
    public class BookingController : Controller
    {
        HMSEntities db = new HMSEntities();
        // GET: Booking
        public ActionResult Index()
        {
            var lst = from b in db.Tbl_Booking
                      join r in db.Tbl_Registration on b.RegistrationId equals r.Id
                      join d in db.Tbl_Doctor on b.DoctorId equals d.Id
                      select new { Id = b.Id, RegistrationName = r.Name, RegistrationId = r.Id, BookingDate = b.BookingDate, DoctorName = d.Name, DoctorId = d.Id, b.Status };
            List<BookingModel> model = new List<BookingModel>();
            foreach (var item in lst)
            {
                model.Add(new BookingModel()
                {
                    Id = item.Id,
                    RegistrationName = item.RegistrationName,
                    RegistrationId = item.RegistrationId,
                    DoctorName = item.DoctorName,
                    DoctorId = item.DoctorId,
                    BookingDate = Convert.ToDateTime(item.BookingDate),
                    Status = item.Status,
                });
            }
            return View(model);
        }
        public ActionResult create()
        {
            ViewBag.lstRegistration = db.Tbl_Registration.ToList();
            ViewBag.lstDoctor = db.Tbl_Doctor.ToList();
            return View();
        }
        public ActionResult Save(Tbl_Booking booking)
        {
            Tbl_Booking item = new Tbl_Booking();
            item.RegistrationId = booking.RegistrationId;
            item.DoctorId = booking.DoctorId;
            item.BookingDate = booking.BookingDate;
            item.Status="Waiting";
            db.Tbl_Booking.Add(item);
            db.SaveChanges();
            return Redirect("/Booking");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.lstRegistration = db.Tbl_Registration.ToList();
            ViewBag.lstDoctor = db.Tbl_Doctor.ToList();
            var item = db.Tbl_Booking.Find(id);
            return View(item);
        }
        public ActionResult Update(int id, Tbl_Booking booking)
        {
            var item = db.Tbl_Booking.Find(id);
            item.RegistrationId = booking.RegistrationId;
            item.DoctorId = booking.DoctorId;
            item.BookingDate = booking.BookingDate;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Booking");
        }
        public ActionResult UpdateStatusById(int id)
        {
            var item = db.Tbl_Booking.Find(id);
            item.Status = "Complete";
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return Redirect("/Booking");
        }
        public ActionResult Delete(int id) 
        {
           
                var item = db.Tbl_Booking.Where(x => x.Id == id).FirstOrDefault();
                db.Tbl_Booking.Remove(item);
                db.SaveChanges();
                return Redirect("/Booking");
            }
        }
    }
