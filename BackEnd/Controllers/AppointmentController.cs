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
    public class AppointmentController : ControllerBase
    {

        IAppointment appointmentRepo;
        public AppointmentController(IAppointment _appointmentRepo)
        {
            appointmentRepo = _appointmentRepo;
        }

        //--- add an appointment ---//
        #region AddAppointment

        [HttpPost]
        //[Authorize]

        public async Task<IActionResult> AddAppointment(Appointments appointment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newPatient = await appointmentRepo.AddAppointment(appointment);
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


        //--- update an appointment ---//
        #region UpdateAppointment

        [HttpPut]
        //[Authorize]

        public async Task<IActionResult> UpdateAppointment(Appointments appointment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newPatient = await appointmentRepo.UpdateAppointment(appointment);
                    if (newPatient != null)
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


        //--- View appointment by date ---//
        #region ViewAppointmentByDate

        [HttpGet("{date}")]
        //[Authorize]

        public async Task<IActionResult> ViewAppointmentByDate(DateTime date)
        {
            try
            {
                var appointment = await appointmentRepo.ViewAppointmentByDate(date);
                if (appointment != null)
                {
                    return Ok(appointment);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion


        //--- View all Appointments ---//
        #region ViewAllAppointments

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> ViewAllAppointments()
        {
            try
            {
                var appointments = await appointmentRepo.ViewAllAppointments();
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


        //--- View Appointment For Doctor ---//
        #region ViewAppointmentForDoctor

        [HttpGet]
        [Route("GetByDoctor")]
        //[Authorize]

        public async Task<IActionResult> ViewAppointmentForDoctor(int id)
        {
            try
            {
                var appointments = await appointmentRepo.ViewAppointmentForDoctor(id);
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


        //--- View Appointment For Doctor ---//
        #region ViewAppointmentForDoctor

        [HttpGet]
        [Route("doctor")]
        //[Authorize]

        public async Task<IActionResult> ViewAppointmentByDoctor(int id)
        {
            try
            {
                var appointments = await appointmentRepo.ViewAppointmentByDoctor(id);
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

        //--- update appointment status---//
        #region UpdateStatus

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await appointmentRepo.UpdateStatus(id);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //--- Delete appointment ---//
        #region DeleteAppointment

        [HttpDelete]
        [Route("delete")]
        //[Authorize]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await appointmentRepo.DeleteAppointment(id);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

    }
}
