using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Appointments
    {
        public int AppointmentId { get; set; }
        public int AppointmentTypeId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
        public int EmployeeId { get; set; }
        public bool AppointmentStatus { get; set; }

        public virtual AppointmentTypes AppointmentType { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
