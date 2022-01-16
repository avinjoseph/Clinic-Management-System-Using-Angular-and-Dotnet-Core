using Clinic_Management_System_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface IRole
    {
        //--- get all Roles ---//
        Task<List<Roles>> GetRoles();
    }
}
