using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentBookingSystem.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public string RegistrationName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }

    }

}