using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Employees = new HashSet<Employees>();
            Login = new HashSet<Login>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Login> Login { get; set; }
    }
}
