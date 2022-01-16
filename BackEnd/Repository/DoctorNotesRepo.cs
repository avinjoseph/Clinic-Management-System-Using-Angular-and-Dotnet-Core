using Clinic_Management_System_8.Models;
using Clinic_Management_System_8.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.Repository
{
    public class DoctorNotesRepo : IDoctorNotesRepo
    {
        private CMSContext dbContext;

        //Dependency Injection
        //--- Parameterized Constructor ---//
        public DoctorNotesRepo(CMSContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<int> AddDoctorNotes(DoctorNotes notes)
        {
            if (dbContext != null)
            {
                await dbContext.DoctorNotes.AddAsync(notes);
                await dbContext.SaveChangesAsync();
                return notes.NoteId;
            }
            return 0;
        }

        public async Task<List<DoctorNotesModel>> ViewDoctorNotesById(int id)
        {
            if (dbContext != null)
            {
                //-- LINQ --//

                return await (from d in dbContext.DoctorNotes
                              from p in dbContext.Patients
                              from e in dbContext.Employees
                              where d.PatientId == p.PatientId &&
                              d.DoctorId == e.EmployeeId && d.PatientId == id
                              select new DoctorNotesModel
                              {
                                  NoteId = d.NoteId,
                                  Note = d.Note,
                                  NoteDate = d.NoteDate,
                                  DoctorName = e.EmployeeName,
                                  PatientName = p.PatientName
                              }).ToListAsync();
            }
            return null;
        }
    }
}
