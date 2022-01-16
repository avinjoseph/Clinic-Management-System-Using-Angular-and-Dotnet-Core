using Clinic_Management_System_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public class Announcement : IAnnouncement
    {
        private CMSContext db;

        //Dependency Injection
        //--- Parameterized Constructor ---//
        public Announcement(CMSContext _dbContext)
        {
            db = _dbContext;
        }

        public async  Task<int> AddAnnouncement(Clinic_Management_System_8.Models.Announcement announcement)
        {

            if (db != null)
            {
                await db.Announcement.AddAsync(announcement);
                await db.SaveChangesAsync();
                return announcement.AnnId;
            }
            return 0;

        }

        public async Task<List<Clinic_Management_System_8.Models.Announcement>> ViewAllAnnouncements()
        {
            if (db != null)
            {
                return await db.Announcement.ToListAsync();
            }
            return null;

        }
    }
}
