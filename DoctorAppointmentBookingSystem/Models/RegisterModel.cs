using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorAppointmentBookingSystem.Models
{
    public class RegisterModel
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}