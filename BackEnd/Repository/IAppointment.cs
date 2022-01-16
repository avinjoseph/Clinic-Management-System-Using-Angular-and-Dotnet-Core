using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public interface IAppointment
    {
        //--- Add Appointment ---//
        Task<int> AddAppointment(Appointments appointment);

        //--- Update Appointment ---//
        Task<Appointments> UpdateAppointment(Appointments appointment);

        //--- View All Appointment ---//
        Task<List<AppointmentViewModel>> ViewAllAppointments();

        //--- View All Appointments of a day ---//
        Task<List<AppointmentViewModel>> ViewAppointmentByDate(DateTime date);

        //--- View Appointments for a particular doctor ---//
        Task<List<AppointmentViewModel>> ViewAppointmentForDoctor(int id);
        Task<List<AppointmentViewModel>> ViewAppointmentByDoctor(int id);

        //--- update Appointment status---/
        Task UpdateStatus(int id);

        //--- Delete Appointment ---/
        Task DeleteAppointment(int id);
    }
}
