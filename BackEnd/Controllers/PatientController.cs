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
    public class PatientController : ControllerBase
    {
        IPatient patientRepo;
        public PatientController(IPatient _patientRepo)
        {
            patientRepo = _patientRepo;
        }

        //--- add a patient ---//
        #region AddPatient

        [HttpPost]
        //[Authorize]

        public async Task<IActionResult> AddPatient(Patients patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newPatient = await patientRepo.AddPatient(patient);
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


        //--- Update Patient ---//
        #region UpdatePatient

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> UpdatePatient([FromBody] Patients patient)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await patientRepo.UpdatePatient(patient);
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


        //--- View all Patients ---//
        #region ViewPatients

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> ViewAllPatients()
        {
            try
            {
                var patient = await patientRepo.ViewAllPatients();
                if (patient != null)
                {
                    return Ok(patient);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        //--- View Patients ---//
        #region ViewPatients

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> ViewPatients()
        {
            try
            {
                var patient = await patientRepo.ViewPatients();
                if (patient != null)
                {
                    return Ok(patient);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion


        //--- View Patient by Id ---//
        #region ViewPatientById

        [HttpGet]
        [Route("ViewPatientById")]
        //[Authorize]
        public async Task<IActionResult> ViewPatientById(int id)
        {
            try
            {
                var patient = await patientRepo.ViewPatientById(id);
                if (patient != null)
                {
                    return Ok(patient);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion


        //--- View Patient by Date ---//
        #region ViewPatientByDate

        [HttpGet("{date}")]
        //[Authorize]
        public async Task<IActionResult> ViewPatientByDate(DateTime date)
        {
            try
            {
                var patients = await patientRepo.ViewPatientByDate(date);
                if (patients != null)
                {
                    return Ok(patients);
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
