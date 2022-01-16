using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmlpoyeeRepo employeeRepo;

        //--- Parameterized constructor ---//
        public EmployeeController(IEmlpoyeeRepo _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }


        //--- Get all Employees ---//
        #region GetEmployees

        [HttpGet]
        //[Authorize]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await employeeRepo.GetEmployees();
                if (employees != null)
                {
                    return Ok(employees);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion


        //--- Get  Employee by id ---//
        #region GetEmployeeById

        [HttpGet]
        //[Authorize]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await employeeRepo.GetEmployeeById(id);
                if (employee != null)
                {
                    return Ok(employee);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        //--- add a new employee ---//
        #region AddEmployee
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employees employee)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var newEmployee = await employeeRepo.AddEmployee(employee);
                    if (newEmployee > 0)
                    {
                        return Ok(newEmployee);

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        //--- update a Employee ---//
        #region UpdateEmployee

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employees employee)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRepo.UpdateEmployee(employee);
                    return Ok(employee);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //--- Delete a Employee -- //
        #region delete user 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteuser(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await employeeRepo.DeleteEmployee(id);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //-- Get All Doctors -- //
        #region GetAllDoctors
        [HttpGet("{id}")]
        //[Authorize]
        //[Route("GetEmployees")]
        public async Task<IActionResult> GetAllDoctors(int id)
        {
            try
            {
                var doctors = await employeeRepo.GetAllDoctors(id);
                if (doctors != null)
                {
                    return Ok(doctors);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion



    }
}
