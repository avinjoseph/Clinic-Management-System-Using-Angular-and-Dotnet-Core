using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface IDoctorNotesRepo
    {
        //--- Add Doctor notes ---//
        Task<int> AddDoctorNotes(DoctorNotes notes);
        //--- View Doctor notes for a particular patient ---//
        Task<List<DoctorNotesModel>> ViewDoctorNotesById(int id);
    }
}
