using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface IPatient
    {

        //--- add Patient ---//
        Task<int> AddPatient(Patients patient);

        //--- update Patient ---//
        Task<Patients> UpdatePatient(Patients patient);

        //--- View Patient ---//
        Task<List<PatientViewModel>> ViewAllPatients();

        //--- View Patient ---//
        Task<List<Patients>> ViewPatients();

        //--- View Patient by Id---//
        Task<Patients> ViewPatientById(int Id);

        //--- View Patient by Id---//
        Task<List<PatientViewModel>> ViewPatientByDate(DateTime date);

    }
}
