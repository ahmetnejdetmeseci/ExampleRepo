using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Improvement
    {
        public int ImprovementId { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Description { get; set; }
        public DateTime ImprovementDate { get; set; }
        public string ImprovementType { get; set; } // "Makine", "Süreç", vb.
        public int Rating { get; set; }
    }
}
