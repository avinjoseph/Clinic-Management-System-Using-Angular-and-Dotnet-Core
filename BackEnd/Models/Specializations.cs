using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Specializations
    {
        public Specializations()
        {
            EmployeeSpecializations = new HashSet<EmployeeSpecializations>();
        }

        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }

        public virtual ICollection<EmployeeSpecializations> EmployeeSpecializations { get; set; }
    }
}
