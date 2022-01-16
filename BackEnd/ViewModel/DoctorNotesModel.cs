using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.ViewModel
{
    public class DoctorNotesModel
    {
        public int NoteId { get; set; }
        public string Note { get; set; }
        public DateTime? NoteDate{ get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
