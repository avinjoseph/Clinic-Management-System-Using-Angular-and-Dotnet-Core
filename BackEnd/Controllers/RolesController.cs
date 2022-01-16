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
    public class RolesController : ControllerBase
    {
        IRole roleRepo;
        public RolesController(IRole _roleRepo)
        {
            roleRepo = _roleRepo;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await roleRepo.GetRoles();
                if (roles != null)
                {
                    return Ok(roles);
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

