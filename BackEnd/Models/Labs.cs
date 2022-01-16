using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Labs
    {
        public Labs()
        {
            LabHasTechnician = new HashSet<LabHasTechnician>();
        }

        public int LabId { get; set; }
        public string LabName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<LabHasTechnician> LabHasTechnician { get; set; }
    }
}
