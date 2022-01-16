using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public class TestReport : ITestReport
    {
        CMSContext _db;

        public TestReport(CMSContext db)
        {
            _db = db;
        }
        //--Add 
        #region add test report
        public async Task<int> AddTestReport(TestReports test)
        {
            if (_db != null)
            {
                await _db.AddAsync(test);
                await _db.SaveChangesAsync();
                return test.TestReportId;
            }
            return 0;
        }
        #endregion
        //delete test report
        #region Delete test report
        public async Task DeleteTestReport(int id)
        {
            //--- locating Testreport by id ---//
            var test = _db.TestReports.FirstOrDefault(e => e.TestReportId == id);
            if (test != null)
            {
                _db.TestReports.Remove(test);
                await _db.SaveChangesAsync();


            }
        }
        #endregion
        //get test reports
        #region Get test reports
        public async Task<List<LabReportModel>> GetTestReport()
            {
                if (_db != null)
                {
                    //LINQ
                    return await (from t in _db.TestReports
                                  from d in _db.Employees
                                  from l in _db.Employees
                                  from p in _db.Patients
                                  where t.DoctorId == d.EmployeeId && t.LabTechnicianId == l.EmployeeId && t.PatientId == p.PatientId
                                  select new LabReportModel
                                  {
                                      TestReportId = t.TestReportId,
                                      TestReport = t.TestReport,
                                      PatientName = p.PatientName,
                                      DoctorName = d.EmployeeName,
                                      LabTechnicianName = l.EmployeeName,
                                      ReportGeneratedDate = t.ReportGeneratedDate
                                  }).ToListAsync();
                }
                return null;
            }
        #endregion

        //get test reports by employee id
        #region Get test reports by employee id
        public async Task<List<LabReportModel>> GetTestReportsByEmpId(int id)
        {
            if (_db != null)
            {
                //LINQ
                return await (from t in _db.TestReports
                              from d in _db.Employees
                              from l in _db.Employees
                              from p in _db.Patients
                              where t.DoctorId == d.EmployeeId && t.LabTechnicianId == l.EmployeeId && t.PatientId == p.PatientId && (t.DoctorId ==id || t.LabTechnicianId == id)
                              select new LabReportModel
                              {
                                  TestReportId = t.TestReportId,
                                  TestReport = t.TestReport,
                                  PatientName = p.PatientName,
                                  DoctorName = d.EmployeeName,
                                  LabTechnicianName = l.EmployeeName,
                                  ReportGeneratedDate = t.ReportGeneratedDate
                              }).ToListAsync();
            }
            return null;
        }
        #endregion


        //get test reports by employee id
        #region Get test reports by patient id
        public async Task<List<LabReportModel>> GetTestReportsByPatientId(int id)
        {
            if (_db != null)
            {
                //LINQ
                return await (from t in _db.TestReports
                              from d in _db.Employees
                              from l in _db.Employees
                              from p in _db.Patients
                              where t.DoctorId == d.EmployeeId && t.LabTechnicianId == l.EmployeeId && t.PatientId == p.PatientId && t.PatientId==id
                              select new LabReportModel
                              {
                                  TestReportId = t.TestReportId,
                                  TestReport = t.TestReport,
                                  PatientName = p.PatientName,
                                  DoctorName = d.EmployeeName,
                                  LabTechnicianName = l.EmployeeName,
                                  ReportGeneratedDate = t.ReportGeneratedDate
                              }).ToListAsync();
            }
            return null;
        }
        #endregion

        //get test report by date
        #region Get test report by date
        public async Task<LabReportModel> GetTestReportByDate(DateTime date)
        {
            if (_db != null)
            {
                //LINQ
                return await (from t in _db.TestReports
                              from d in _db.Employees
                              from l in _db.Employees
                              from p in _db.Patients
                              where t.DoctorId == d.EmployeeId && t.LabTechnicianId == l.EmployeeId && t.PatientId == p.PatientId && t.ReportGeneratedDate==date
                              select new LabReportModel
                              {
                                  TestReportId = t.TestReportId,
                                  TestReport = t.TestReport,
                                  PatientName = p.PatientName,
                                  DoctorName = d.EmployeeName,
                                  LabTechnicianName = l.EmployeeName,
                                  ReportGeneratedDate = t.ReportGeneratedDate
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
        //get test report by using id
        #region get test report by id
        public async Task<TestReports> GetTestReportById(int id)
        {
            if (_db != null)
            {
                //LINQ
                 return await _db.TestReports.FirstOrDefaultAsync(t => t.TestReportId == id);
            }
            return null;
        }
        #endregion
        //update test report by id
        #region Update test report 
        public async Task UpdateTestReport(TestReports test)
        {
            if (_db != null)
            {
                _db.TestReports.Update(test);
                await _db.SaveChangesAsync();
            }
        }
        #endregion
    }
}
