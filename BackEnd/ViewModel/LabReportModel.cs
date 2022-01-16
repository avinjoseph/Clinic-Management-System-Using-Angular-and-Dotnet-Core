using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.ViewModel
{
    public class LabReportModel
    {
        public int TestReportId { get; set; }
        public string TestReport { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string LabTechnicianName { get; set; }
        public DateTime ReportGeneratedDate { get; set; }
    }
}
