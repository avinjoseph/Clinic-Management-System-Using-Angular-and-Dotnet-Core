using Clinic_Management_System_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public class Role : IRole
    {
        private CMSContext db;

        //Dependency Injection
        //--- Parameterized Constructor ---//
        public Role(CMSContext _db)
        {
            db = _db;
        }

        public async Task<List<Roles>> GetRoles()
        {
            if (db != null)
            {
                return await db.Roles.ToListAsync();
            }
            return null;
        }
    }
}
