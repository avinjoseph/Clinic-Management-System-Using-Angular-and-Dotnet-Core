using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.ViewModel
{
    public class EmployeeModel
    {

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public decimal MobileNo { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfJoining { get; set; }

        //public string Specialization { get; set; }

        public string DepartmentName { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
