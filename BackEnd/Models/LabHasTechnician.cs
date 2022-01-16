using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class LabHasTechnician
    {
        public int Ltid { get; set; }
        public int LabId { get; set; }
        public int LabTechnicianId { get; set; }

        public virtual LabTests Lab { get; set; }
        public virtual Employees LabTechnician { get; set; }
    }
}
