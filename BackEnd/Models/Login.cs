using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Login
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Roles Role { get; set; }
    }
}
