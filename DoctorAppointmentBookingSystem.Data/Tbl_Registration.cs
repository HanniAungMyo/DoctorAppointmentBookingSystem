//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoctorAppointmentBookingSystem.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Registration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public string PhoneNo { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public Nullable<int> MaritalStatusId { get; set; }
        public Nullable<int> NameTypeId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
