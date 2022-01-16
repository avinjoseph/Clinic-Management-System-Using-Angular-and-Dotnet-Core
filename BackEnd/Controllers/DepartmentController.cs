using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class DepartmentController : ControllerBase
    {
        IDepartment deptRepo;
        public DepartmentController(IDepartment _deptRepo)
        {
            deptRepo = _deptRepo;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = await deptRepo.GetDepartments();
                if (departments != null)
                {
                    return Ok(departments);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getSpecializations")]
        //[Authorize]
        public async Task<IActionResult> GetSpecializations()
        {
            try
            {
                var departments = await deptRepo.GetSpecializations();
                if (departments != null)
                {
                    return Ok(departments);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSpecializations(EmployeeSpecializations specializations)
        {
            try
            {
                var specializationId = await deptRepo.AddSpecializations(specializations);
                if (specializationId >0)
                {
                    return Ok(specializationId);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
