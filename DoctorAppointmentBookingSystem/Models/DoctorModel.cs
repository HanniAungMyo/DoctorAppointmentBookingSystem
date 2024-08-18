using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentBookingSystem.Models
{
    public class DoctorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecialityId {  get; set; }
        public string SpecialityName { get; set; }
        public int DoctorFees { get; set;}
    }
}