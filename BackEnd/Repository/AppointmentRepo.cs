using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public class AppointmentRepo : IAppointment
    {
        private CMSContext dbContext;

        //Dependency Injection
        //--- Parameterized Constructor ---//
        public AppointmentRepo(CMSContext _dbContext)
        {
            dbContext = _dbContext;
        }

        //--- Add Appointments ---//
        #region AddAppointment

        public async Task<int> AddAppointment(Appointments appointment)
        {
            if (dbContext != null)
            {
                await dbContext.Appointments.AddAsync(appointment);
                await dbContext.SaveChangesAsync();
                return appointment.AppointmentId;
            }
            return 0;
        }

        #endregion


        //--- Update Appointments ---//
        #region UpdateAppointment

        public async Task<Appointments> UpdateAppointment(Appointments appointment)
        {
            if (dbContext != null)
            {
                dbContext.Appointments.Update(appointment);
                await dbContext.SaveChangesAsync();
                return appointment;
            }
            return null;
        }

        #endregion


        //--- View Appointment By Date ---//
        #region ViewAppointmentByDate

        public async Task<List<AppointmentViewModel>> ViewAppointmentByDate(DateTime date)
        {
            //--- get appointment by id ---//
            if (dbContext != null)
            {
                //-- LINQ --//
                //-- joining Appointments, AppointmentTypes, Patients and Employees  --//
                return await (from a in dbContext.Appointments
                              from at in dbContext.AppointmentTypes
                              from p in dbContext.Patients
                              from e in dbContext.Employees
                              where a.AppointmentTypeId == at.AppointmentTypeId &&
                              a.PatientId == p.PatientId &&
                              a.EmployeeId == e.EmployeeId
                              select new AppointmentViewModel
                              {
                                  AppointmentId = a.AppointmentId,
                                  PatientId = p.PatientId,
                                  AppointmentType = at.AppointmentType,
                                  PatientName = p.PatientName,
                                  Age = p.Age,
                                  MobileNo = p.MobileNo,
                                  Gender = p.Gender,
                                  Address = p.Address,
                                  EmployeeId = e.EmployeeId,
                                  EmployeeName = e.EmployeeName,
                                  AppointmentStatus = a.AppointmentStatus,
                                  AppointmentDate = a.AppointmentDate
                              }).ToListAsync();
            }
            return null;
        }

        #endregion


        //--- View all Appointment ---//
        #region ViewAllAppointments

        public async Task<List<AppointmentViewModel>> ViewAllAppointments()
        {
            if (dbContext != null)
            {
                DateTime date = DateTime.Today;
                //-- LINQ --//
                //-- joining Appointments, AppointmentTypes, Patients and Employees  --//
                return await (from a in dbContext.Appointments
                              from at in dbContext.AppointmentTypes
                              from p in dbContext.Patients
                              from e in dbContext.Employees
                              from r in dbContext.Roles
                              where a.AppointmentTypeId == at.AppointmentTypeId &&
                              a.PatientId == p.PatientId &&
                              a.EmployeeId == e.EmployeeId &&
                              a.AppointmentDate == date 


                              select new AppointmentViewModel
                              {
                                  AppointmentId = a.AppointmentId,
                                  PatientId = p.PatientId,
                                  AppointmentType = at.AppointmentType,
                                  PatientName = p.PatientName,
                                  Age = p.Age,
                                  MobileNo = p.MobileNo,
                                  Gender = p.Gender,
                                  Address = p.Address,
                                  EmployeeId=e.EmployeeId,
                                  EmployeeName = e.EmployeeName,
                                  AppointmentStatus = a.AppointmentStatus,
                                  AppointmentDate = a.AppointmentDate
                              }).ToListAsync();
            }

            return null;
        }

        #endregion


        //--- View Appointments for a particular doctor ---//
        #region ViewAppointmentForDoctor

        public async Task<List<AppointmentViewModel>> ViewAppointmentForDoctor(int id)
        {
            DateTime date = DateTime.Now; 
            //--- get appointment by Doctorid ---//
            if (dbContext != null)
            {
                //-- LINQ --//
                //-- joining Appointments, AppointmentTypes, Patients and Employees  --//
                return await (from a in dbContext.Appointments
                              from at in dbContext.AppointmentTypes
                              from p in dbContext.Patients
                              from e in dbContext.Employees
                              where a.AppointmentTypeId == at.AppointmentTypeId &&
                              a.EmployeeId == id &&
                              a.PatientId == p.PatientId &&
                              a.EmployeeId == e.EmployeeId &&
                              e.EmployeeId == id && a.AppointmentDate == date && a.AppointmentStatus == true

                              select new AppointmentViewModel
                              {
                                  AppointmentId = a.AppointmentId,
                                  PatientId = p.PatientId,
                                  AppointmentType = at.AppointmentType,
                                  PatientName = p.PatientName,
                                  Age = p.Age,
                                  MobileNo = p.MobileNo,
                                  Gender = p.Gender,
                                  Address = p.Address,
                                  EmployeeName = e.EmployeeName,
                                  AppointmentStatus = a.AppointmentStatus,
                                  AppointmentDate = a.AppointmentDate
                              }).ToListAsync();
            }
            return null;
        }


        #endregion


        //--- View Appointments for a particular doctor ---//
        #region ViewAppointmentbyDoctor

        public async Task<List<AppointmentViewModel>> ViewAppointmentByDoctor(int id)
        {
            DateTime date = DateTime.Now;
            //--- get appointment by Doctorid ---//
            if (dbContext != null)
            {
                //-- LINQ --//
                //-- joining Appointments, AppointmentTypes, Patients and Employees  --//
                return await (from a in dbContext.Appointments
                              from at in dbContext.AppointmentTypes
                              from p in dbContext.Patients
                              from e in dbContext.Employees
                              where a.AppointmentTypeId == at.AppointmentTypeId &&
                              a.PatientId == p.PatientId &&
                              a.EmployeeId == e.EmployeeId &&
                              e.RoleId == id

                              select new AppointmentViewModel
                              {
                                  AppointmentId = a.AppointmentId,
                                  PatientId = p.PatientId,
                                  AppointmentType = at.AppointmentType,
                                  PatientName = p.PatientName,
                                  Age = p.Age,
                                  MobileNo = p.MobileNo,
                                  Gender = p.Gender,
                                  Address = p.Address,
                                  EmployeeName = e.EmployeeName,
                                  AppointmentStatus = a.AppointmentStatus,
                                  AppointmentDate = a.AppointmentDate
                              }).ToListAsync();
            }
            return null;
        }


        #endregion

        //--- Delete the appointment ---//

        #region UpdateStatus
        public async Task UpdateStatus(int id)
        {
            Appointments appointment = dbContext.Appointments.FirstOrDefault(Aid => Aid.AppointmentId == id);
            if (appointment != null)
            {
                appointment.AppointmentStatus = false;
                await dbContext.SaveChangesAsync();
            }
        }
        #endregion

        //--- Delete the appointment ---//

        #region DeleteAppointment
        public async Task DeleteAppointment(int id)
        {
            Appointments appointment = dbContext.Appointments.FirstOrDefault(Aid => Aid.AppointmentId == id);
            if (appointment != null)
            {
                dbContext.Appointments.Remove(appointment);
                await dbContext.SaveChangesAsync();
            }
        }
        #endregion



    }
}
