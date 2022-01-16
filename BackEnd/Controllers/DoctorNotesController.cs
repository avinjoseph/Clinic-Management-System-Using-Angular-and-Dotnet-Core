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
    public class DoctorNotesController : ControllerBase
    {
        IDoctorNotesRepo db;
        public DoctorNotesController(IDoctorNotesRepo _db)
        {
            db = _db;
        }
        //--- add DoctorNotesRepo ---//
        #region Add Doctor notes

        [HttpPost]
        //[Authorize]

        public async Task<IActionResult> AddDoctorNotes(DoctorNotes notes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newnote = await db.AddDoctorNotes(notes);
                    if (newnote > 0)
                    {
                        return Ok(newnote);
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
        //--- View all Doctor notes ---//
        #region ViewDoctorNotes

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> ViewDoctorNotesById(int id)
        {
            try
            {
                var notes = await db.ViewDoctorNotesById(id);
                if (notes != null)
                {
                    return Ok(notes);
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
