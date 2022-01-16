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
    public class PrescriptionController : ControllerBase
    {
        IPrescription preRepo;
        public PrescriptionController(IPrescription _p)
        {
            preRepo = _p;
        }
        //--- Get all Prescription ---//
        #region Get all Prescription

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetPrescriptionDetails()
        {
            try
            {
                var notes = await preRepo.GetPrescriptionDetails();
                if (notes == null)
                {
                    return NotFound();
                }
                return Ok(notes);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        //--- Prescription for a period ---//
        #region Prescription for a period

        [HttpGet]
        //[Authorize]
        [Route("Upto")]
        public async Task<IActionResult> GetPrescriptionForPeriod(DateTime date)
        {
            try
            {
                var prescription = await preRepo.GetPrescriptionForPeriod(date);
                if (prescription == null)
                {
                    return NotFound();
                }
                return Ok(prescription);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
#endregion

        //--- Add prescription ---//
        #region Add prescription
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddPrescription(Prescriptions note)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var prescription = await preRepo.AddPrescription(note);
                    if (prescription > 0)
                    {
                        return Ok(prescription);
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

        //--- Update Prescription ---//
        #region update prescription
        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> UpdatePrescription(Prescriptions note)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await preRepo.UpdatePrescription(note);
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

        //--- Get Prescription By PatientId  ---//
        #region Get Prescription By PatientId 
        [HttpGet]
        [Route("test")]
        //[Authorize]
        public async Task<IActionResult> GetPrescriptionByPatientId(int id)
        {
            try
            {
                var patient = await preRepo.GetPrescriptionByPatientId(id); ;
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


        //--- Get Prescription By Id  ---//
        #region Get Prescription By PatientId 
        [HttpGet]
        [Route("reportById")]
        //[Authorize]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            try
            {
                var patient = await preRepo.GetPrescriptionById(id); ;
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

        //--- Get prescription by date ---//
        #region Get Prescription By date
        [HttpGet("{date}")]
        //[Authorize]
        public async Task<IActionResult> GetPrescriptionByDate(DateTime date)
        {
            try
            {
                var patient = await preRepo.GetPrescriptionByDate(date);
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


        #region GetAllPrescriptions
        [HttpGet]
        [Route("GetAllPrescriptions")]
        //[Authorize]
        public async Task<IActionResult> GetAllPrescriptions(int id)
        {
            try
            {
                var patient = await preRepo.GetAllPrescriptions(id); ;
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



    }
}

   