using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentBookingSystem.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNo { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public int MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; }
        public int NamTypeId { get; set; }
        public string NameType { get; set; }

    }
}