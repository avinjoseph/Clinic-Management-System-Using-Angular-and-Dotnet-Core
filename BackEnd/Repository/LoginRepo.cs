using Clinic_Management_System_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public class LoginRepo : ILogin
    {
        private CMSContext db;

        //Dependency Injection
        //--- Parameterized Constructor ---//
        public LoginRepo(CMSContext _db)
        {
            db = _db;
        }

        //add ogin details
        public async Task<int> AddLogin(Login login)
        {
            if (db != null)
            {
                await db.Login.AddAsync(login);
                await db.SaveChangesAsync();
                return login.LoginId;
            }
            return 0;
        }
    }
}
