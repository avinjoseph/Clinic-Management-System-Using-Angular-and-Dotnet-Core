using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public class Prescription : IPrescription
    {
        CMSContext _db;

        public Prescription(CMSContext db)
        {
            _db = db;
        }

        //---  Adding Prescription ---//
        #region Prescription added
        public async Task<int> AddPrescription(Prescriptions note)
        {
           
                if (_db != null)
                {
                    await _db.Prescriptions.AddAsync(note);
                    await _db.SaveChangesAsync();
                    return note.PrescriptionId;
                }
                return 0;


        }

        #endregion


        //--- Get Prescription By Date  ---//
        #region GetPrescriptionByDate
        public async Task<PrescriptionViewModel> GetPrescriptionByDate(DateTime date)
        {
            if (_db != null)
            {
                //LINQ
                return await (from p in _db.Prescriptions
                              from e in _db.Employees
                              from t in _db.Patients
                              where p.EmployeeId == e.EmployeeId && p.PatientId == t.PatientId && p.PrescriptionDate == date
                              select new PrescriptionViewModel
                              {
                                  PrescriptionId = p.PrescriptionId,
                                  Prescription = p.Prescription,
                                  PrescriptionDate = p.PrescriptionDate,
                                  PatientId = t.PatientId,
                                  PatientName = t.PatientName,
                                  DoctorId = e.EmployeeId,
                                  DoctorName = e.EmployeeName,
                                  Tests = p.Tests
                              }).FirstOrDefaultAsync();
            }
            return null;

        }
        #endregion

        //---  Get prescription by patient id  ---//
        #region GetPrescriptionByPatientId
        public async Task<PrescriptionViewModel> GetPrescriptionByPatientId(int id)
        {
            if (_db != null)
            {
                //LINQ
                return await (from p in _db.Prescriptions
                              from t in _db.Patients
                              from e in _db.Employees
                              where p.PatientId == t.PatientId && p.PatientId == id && p.EmployeeId == e.EmployeeId
                              select new PrescriptionViewModel
                              {
                                  PrescriptionId = p.PrescriptionId,
                                  Prescription = p.Prescription,
                                  PrescriptionDate = p.PrescriptionDate,
                                  PatientId = t.PatientId,
                                  PatientName = t.PatientName,
                                  DoctorId = e.EmployeeId,
                                  DoctorName = e.EmployeeName,
                                  Tests = p.Tests
                              }).OrderByDescending(o=>o.PrescriptionDate).FirstOrDefaultAsync();
            }
            return null;

        }
        #endregion


        //---  Get prescription by  id  ---//
        #region GetPrescriptionById
        public async Task<PrescriptionViewModel> GetPrescriptionById(int id)
        {
            if (_db != null)
            {
                //LINQ
                return await (from p in _db.Prescriptions
                              from t in _db.Patients
                              from e in _db.Employees
                              where p.PatientId == t.PatientId && p.PrescriptionId == id && p.EmployeeId == e.EmployeeId
                              select new PrescriptionViewModel
                              {
                                  PrescriptionId = p.PrescriptionId,
                                  Prescription = p.Prescription,
                                  PrescriptionDate = p.PrescriptionDate,
                                  PatientId = t.PatientId,
                                  PatientName = t.PatientName,
                                  DoctorId = e.EmployeeId,
                                  DoctorName = e.EmployeeName,
                                  Tests = p.Tests
                              }).FirstOrDefaultAsync();
            }
            return null;

        }
        #endregion


        //--- Get prescription Details ---//
        #region GetPrescriptionDetails
        public async Task<List<PrescriptionViewModel>> GetPrescriptionDetails()
        {
            if (_db != null)
            {
                //LINQ
                return await (from p in _db.Prescriptions
                              from e in _db.Employees
                              from t in _db.Patients
                              where p.EmployeeId == e.EmployeeId && p.PatientId == t.PatientId
                              select new PrescriptionViewModel
                              {
                                  PrescriptionId = p.PrescriptionId,
                                  Prescription = p.Prescription,
                                  PrescriptionDate = p.PrescriptionDate,
                                  PatientId = t.PatientId,
                                  PatientName = t.PatientName
                              }).ToListAsync();
            }
            return null;
        }
        #endregion

        //--- Get Prescription for period ---//
        #region GetPrescriptionForPeriod
        public async Task<List<PrescriptionViewModel>> GetPrescriptionForPeriod(DateTime date)
        {
            if (_db != null)
            {
                //LINQ
                return await (from p in _db.Prescriptions
                              from t in _db.Patients 
                              where p.PatientId == t.PatientId && p.PrescriptionDate < date
                              select new PrescriptionViewModel
                              {
                                  PrescriptionId = p.PrescriptionId,
                                  Prescription = p.Prescription,
                                  PrescriptionDate = p.PrescriptionDate,
                                  PatientId = t.PatientId,
                                  PatientName = t.PatientName
                              }).ToListAsync();
            }
            return null;
        }
        #endregion

        //--- Update Prescription ---//
        #region UpdatePrescription
        public async Task UpdatePrescription(Prescriptions note)
        {
            if (_db != null)
            {
                _db.Prescriptions.Update(note);
                await _db.SaveChangesAsync();
            }
        }
        #endregion



        #region GetAllPrescriptions
        public async Task<List<PrescriptionViewModel>> GetAllPrescriptions(int id)
        {
            if (_db != null)
            {
                //LINQ
                return await (from p in _db.Prescriptions
                              from t in _db.Patients
                              from e in _db.Employees
                              where p.PatientId == t.PatientId && p.PatientId == id && p.EmployeeId == e.EmployeeId
                              select new PrescriptionViewModel
                              {
                                  PrescriptionId = p.PrescriptionId,
                                  Prescription = p.Prescription,
                                  PrescriptionDate = p.PrescriptionDate,
                                  PatientId = t.PatientId,
                                  PatientName = t.PatientName,
                                  DoctorId = e.EmployeeId,
                                  DoctorName = e.EmployeeName,
                                  Tests = p.Tests
                              }).ToListAsync();
            }
            return null;

        }
        #endregion

    }
}
