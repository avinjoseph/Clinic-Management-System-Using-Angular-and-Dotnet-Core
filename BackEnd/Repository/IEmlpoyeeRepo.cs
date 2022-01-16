using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface IEmlpoyeeRepo
    {
        //--- get all employees ---//
        Task<List<EmployeeModel>> GetEmployees();

        //--- get employee by id ---//
        Task<Employees> GetEmployeeById(int id);

        //--- add Employee ---//
        Task<int> AddEmployee(Employees employee);


        //--- update Employee ---//
        Task<Employees> UpdateEmployee(Employees employee);

        //--- delete Employee by id---//

        Task DeleteEmployee(int id);

        //-- View All Doctors Details --//
        Task<List<DoctorModel>> GetAllDoctors(int id);
    }
}
