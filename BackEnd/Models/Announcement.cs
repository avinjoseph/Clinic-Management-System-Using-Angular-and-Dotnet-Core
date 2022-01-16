using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Announcement
    {
        public int AnnId { get; set; }
        public string AnnText { get; set; }
        public DateTime? AnnDate { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
