using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public int PatientId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; }

        public virtual Patients Patient { get; set; }
    }
}
