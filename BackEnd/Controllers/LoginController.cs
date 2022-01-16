using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _config;
        ILogin loginRepo;
        CMSContext contextDB;

        //--- dependency injection for configuration ---//
        public LoginController(IConfiguration config, CMSContext _contextDB, ILogin _loginRepo)
        {
            _config = config;
            contextDB = _contextDB;
            loginRepo = _loginRepo;
        }


        //--- add login details ---//
        #region AddLoginDetails

        [HttpPost]
        //[Authorize]

        public async Task<IActionResult> AddLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newUser = await loginRepo.AddLogin(login);
                    if (newUser > 0)
                    {
                        return Ok(newUser);
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


        [AllowAnonymous]
        [HttpGet("{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            IActionResult response = Unauthorized();


            //--- Authenticate the user ---//
            Login user = AuthenticateUser(username, password);
            

            //--- validate ---//
            if (user != null)
            {
                Employees emp = contextDB.Employees.FirstOrDefault(e => e.EmployeeId == user.EmployeeId);
                var tokenString = GenerateJWT(username, password);
                response = Ok(new { UserName = user.UserName, RoleId = user.RoleId, Token = tokenString, EmployeeId = user.EmployeeId, Name = emp.EmployeeName });
                return response;
            }
            return response;
        }

        private Login AuthenticateUser(string username, string password)
        {
            //-- Validate the user credentials --//
            Login user = contextDB.Login.FirstOrDefault(us => us.UserName == username && us.Password == password);
            if (user != null)
                return user;
            else
                return null;
        }

        private string GenerateJWT(string username, string password)
        {
            //--- getting security ---//
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //--- signing credentials ---//
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //--- generate the token ---//
            var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                    );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
