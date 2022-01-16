using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class DoctorNotes
    {
        public int NoteId { get; set; }
        public string Note { get; set; }
        public DateTime? NoteDate { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public virtual Employees Doctor { get; set; }
        public virtual Patients Patient { get; set; }
    }
}
