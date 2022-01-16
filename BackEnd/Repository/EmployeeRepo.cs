using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public class EmployeeRepo : IEmlpoyeeRepo
    {
        private CMSContext db;

        //Dependency Injection
        //--- Parameterized Constructor ---//
        public EmployeeRepo(CMSContext _db)
        {
            db = _db;
        }

        //--- member function to add a new employee ---//
        #region AddEmployee
        public async Task<int> AddEmployee(Employees employee)
        {
            if (db != null)
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
                return employee.EmployeeId;
            }
            return 0;
        }
        #endregion


        //--- member function to delete a employee ---//
        #region DeleteEmployee
        public async Task DeleteEmployee(int id)
        {
            //--- locating employee by id ---//

            Employees employee = db.Employees.FirstOrDefault(eid => eid.EmployeeId == id);
            if (employee != null)
            {
                employee.IsActive = false;
                await db.SaveChangesAsync();
            }
        }
        #endregion


        //--- member function to get employee by id ---//
        #region GetEmployeeById

        public async Task<Employees> GetEmployeeById(int id)
        {
            if (db != null)
            {
                return await db.Employees.FirstOrDefaultAsync(e=>e.EmployeeId==id);
            }
            return null;
        }
        #endregion


        //--- member function to get employees ---//
        #region GetEmployees
        public async Task<List<EmployeeModel>> GetEmployees()
        {
            if (db != null)
            {
                return await(from e in db.Employees
                             from r in db.Roles
                             from d in db.Departments

                             where e.RoleId == r.RoleId && e.DepartmentId == d.DepartmentId
                             select new EmployeeModel
                             {
                                 EmployeeId = e.EmployeeId,
                                 EmployeeName = e.EmployeeName,
                                 Age = e.Age,
                                 MobileNo = e.MobileNo,
                                 Gender = e.Gender,
                                 DateOfJoining = e.DateOfJoining,
                                 DepartmentName = d.DepartmentName,
                                 RoleName = r.RoleName,
                                 IsActive = e.IsActive
                             }).ToListAsync();
            }
            return null;
        }
        #endregion


        //--- member function to update a employee ---//
        #region UpdateEmployee
        public async Task<Employees> UpdateEmployee(Employees employee)
        {
            if (db != null)
            {
                db.Employees.Update(employee);
                await db.SaveChangesAsync();
                return employee;
            }
            return null;
        }
        #endregion

        //--- member function to get all doctors ---//
        #region GetAllDoctors
        public async Task<List<DoctorModel>> GetAllDoctors(int id)
        {
            if (db != null)
            {
                return await (from e in db.Employees
                              from r in db.Roles
                              from es in db.EmployeeSpecializations
                              from s in db.Specializations
                              where e.RoleId == r.RoleId && e.EmployeeId == es.EmployeeId && es.SpecializationId == s.SpecializationId && e.RoleId == id
                              select new DoctorModel
                              {
                                  EmployeeId = e.EmployeeId,
                                  EmployeeName = e.EmployeeName,
                                  Age = e.Age,
                                  MobileNo = e.MobileNo,
                                  Gender = e.Gender,
                                  DateOfJoining = e.DateOfJoining,
                                  Specialization = s.SpecializationName,
                                  IsActive = e.IsActive
                              }).ToListAsync();
            }
            return null;
        }
        #endregion

    }
}
