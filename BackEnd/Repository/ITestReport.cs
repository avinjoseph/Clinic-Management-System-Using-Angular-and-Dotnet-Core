using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface ITestReport
    {
        
        Task<List<LabReportModel>> GetTestReport();

        Task<List<LabReportModel>> GetTestReportsByEmpId(int id);
        Task<List<LabReportModel>> GetTestReportsByPatientId(int id);

        Task<int> AddTestReport(TestReports test);
        Task UpdateTestReport(TestReports test);
        
        Task DeleteTestReport(int id);
        Task<LabReportModel> GetTestReportByDate(DateTime date);
        Task<TestReports> GetTestReportById(int id);
    }
}
