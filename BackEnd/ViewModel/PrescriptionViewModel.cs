using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.ViewModel
{
    public class PrescriptionViewModel
    {
        public int PrescriptionId { get; set; }
        public string Prescription { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int PatientId { get; set; }
        public string  PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Tests { get; set; }

    }
}
