using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.ViewModel
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public String AppointmentType { get; set; }
        public String PatientName { get; set; }
        public int Age { get; set; }
        public decimal MobileNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public String EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public bool AppointmentStatus { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
