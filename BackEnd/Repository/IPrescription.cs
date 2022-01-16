using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface IPrescription
    {
        Task<List<PrescriptionViewModel>> GetPrescriptionDetails();
        Task<int> AddPrescription(Prescriptions note);
        Task UpdatePrescription(Prescriptions note);
       
        Task<PrescriptionViewModel> GetPrescriptionByPatientId(int id);
        Task<PrescriptionViewModel> GetPrescriptionById(int id);
        Task<PrescriptionViewModel> GetPrescriptionByDate(DateTime date);
        Task<List<PrescriptionViewModel>> GetPrescriptionForPeriod(DateTime date);

        Task<List<PrescriptionViewModel>> GetAllPrescriptions(int id);


    }
}
