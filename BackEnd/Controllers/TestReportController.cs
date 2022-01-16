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
    public class TestReportController : ControllerBase
    {
        ITestReport postRepository;
        public TestReportController(ITestReport _p)
        {
            postRepository = _p;
        }
        //Get test reports
        #region Get test report

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetTestReport()
        {
            try
            {
                var tests = await postRepository.GetTestReport();
                if (tests == null)
                {
                    return NotFound();
                }
                return Ok(tests);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        //Get test reports by employee Id
        #region Get test report by empid

        [HttpGet]
        [Route("byEmployeeId")]
        //[Authorize]

        public async Task<IActionResult> GetTestReportsByEmpId(int id)
        {
            try
            {
                var tests = await postRepository.GetTestReportsByEmpId(id);
                if (tests == null)
                {
                    return NotFound();
                }
                return Ok(tests);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion

        //Get test reports by patient Id
        #region Get test report by patientid

        [HttpGet]
        [Route("byPatientId")]
        //[Authorize]

        public async Task<IActionResult> GetTestReportsByPatientId(int id)
        {
            try
            {
                var tests = await postRepository.GetTestReportsByPatientId(id);
                if (tests == null)
                {
                    return NotFound();
                }
                return Ok(tests);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion


        //add one test report 
        #region Add test report
        [HttpPost]
        [Route("add")]
        //[Authorize]
        public async Task<IActionResult> AddTestReport(TestReports test)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var testId = await postRepository.AddTestReport(test);
                    if (testId>0)
                    {
                        return Ok(testId);
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

        //update test report by passing id
        #region update test report
        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> UpdateTestReport(TestReports test)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await postRepository.UpdateTestReport(test);
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
        //get report by id
        #region Getreport by id
        [HttpGet]
        [Route("GetTestReportById")]
        public async Task<IActionResult> GetTestReportById(int id)
        {
            try
            {
                var test = await postRepository.GetTestReportById(id);
                if (test != null)
                {
                    return Ok(test);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
        //get report by passing date
        #region Getreport by date
        [HttpGet("{date}")]
        public async Task<IActionResult> GetTestReportByDate(DateTime date)
        {
            try
            {
                var test = await postRepository.GetTestReportByDate(date);
                if (test != null)
                {
                    return Ok(test);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
        //delete by using id
        #region delete by using id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestReport(int id)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await postRepository.DeleteTestReport(id);
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
