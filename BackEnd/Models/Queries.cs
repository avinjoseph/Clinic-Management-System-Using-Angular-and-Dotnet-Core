using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class Queries
    {
        public int QueryId { get; set; }
        public string Query { get; set; }
        public bool? IsAnswered { get; set; }
        public int? AnsweredBy { get; set; }

        public virtual Employees AnsweredByNavigation { get; set; }
    }
}
