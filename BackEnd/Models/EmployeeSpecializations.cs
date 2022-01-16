using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class EmployeeSpecializations
    {
        public int Esid { get; set; }
        public int SpecializationId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Specializations Specialization { get; set; }
    }
}
