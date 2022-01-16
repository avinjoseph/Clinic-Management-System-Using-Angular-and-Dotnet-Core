using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Prescriptions
    {
        public int PrescriptionId { get; set; }
        public string Prescription { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int EmployeeId { get; set; }
        public int PatientId { get; set; }
        public string Tests { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
