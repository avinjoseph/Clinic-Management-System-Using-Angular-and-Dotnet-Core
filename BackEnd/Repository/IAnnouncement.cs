using Clinic_Management_System_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface IAnnouncement
    {
        //--- Add Announcement ---//
        Task<int> AddAnnouncement(Clinic_Management_System_8.Models.Announcement announcement);
        //--- View All Announcements ---//
        Task<List<Clinic_Management_System_8.Models.Announcement>> ViewAllAnnouncements();
        
    }
}
