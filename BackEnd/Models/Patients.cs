using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Patients
    {
        public Patients()
        {
            Appointments = new HashSet<Appointments>();
            DoctorNotes = new HashSet<DoctorNotes>();
            Payments = new HashSet<Payments>();
            Prescriptions = new HashSet<Prescriptions>();
            TestReports = new HashSet<TestReports>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public decimal MobileNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
        public virtual ICollection<DoctorNotes> DoctorNotes { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<Prescriptions> Prescriptions { get; set; }
        public virtual ICollection<TestReports> TestReports { get; set; }
    }
}
