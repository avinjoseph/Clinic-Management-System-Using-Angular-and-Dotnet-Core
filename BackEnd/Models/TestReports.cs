using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class TestReports
    {
        public int TestReportId { get; set; }
        public DateTime ReportGeneratedDate { get; set; }
        public string TestReport { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int LabTechnicianId { get; set; }

        public virtual Employees Doctor { get; set; }
        public virtual Employees LabTechnician { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
