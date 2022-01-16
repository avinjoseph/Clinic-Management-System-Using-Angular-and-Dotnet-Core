using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.ViewModel
{
    public class PatientViewModel
    {

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public decimal MobileNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string ConsultingDoctor { get; set; }
        public DateTime AppointedDate { get; set; }
    }
}
