using System;
using System.Collections.Generic;

namespace Clinic_Management_System_8.Models
{
    public partial class LabTests
    {
        public LabTests()
        {
            LabHasTechnician = new HashSet<LabHasTechnician>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }

        public virtual ICollection<LabHasTechnician> LabHasTechnician { get; set; }
    }
}
