using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
