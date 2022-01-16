using Clinic_Management_System_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface IDepartment
    {
        //--- get all departments ---//
        Task<List<Departments>> GetDepartments();

        //--- get all specialization ---//
        Task<List<Specializations>> GetSpecializations();

        //--- add specialization ---//
        Task<int> AddSpecializations(EmployeeSpecializations specializations);
    }
}
