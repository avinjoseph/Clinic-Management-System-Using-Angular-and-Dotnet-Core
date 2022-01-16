using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class AppointmentTypes
    {
        public AppointmentTypes()
        {
            Appointments = new HashSet<Appointments>();
        }

        public int AppointmentTypeId { get; set; }
        public string AppointmentType { get; set; }

        public virtual ICollection<Appointments> Appointments { get; set; }
    }
}
