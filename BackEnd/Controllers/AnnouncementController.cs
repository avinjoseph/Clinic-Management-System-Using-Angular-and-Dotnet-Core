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
    public class AnnouncementController : ControllerBase
    {
        IAnnouncement announcementRepo;
        public AnnouncementController(IAnnouncement _announcementRepo)
        {
            announcementRepo = _announcementRepo;
        }
        //--- add Announcement ---//
        #region AddAnnouncement

        [HttpPost]
        //[Authorize]

        public async Task<IActionResult> AddAnnouncement(Clinic_Management_System_8.Models.Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newPatient = await announcementRepo.AddAnnouncement(announcement);
                    if (newPatient > 0)
                    {
                        return Ok(newPatient);
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
        //--- View all Announcement ---//
        #region ViewAllAnnouncements

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> ViewAllAnnouncements()
        {
            try
            {
                var appointments = await announcementRepo.ViewAllAnnouncements();
                if (appointments != null)
                {
                    return Ok(appointments);
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
