using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System_8.ViewModel
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PatientName { get; set; }
        public string Status { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
