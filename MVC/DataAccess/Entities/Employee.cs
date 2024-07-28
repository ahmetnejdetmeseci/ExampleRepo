using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace DataAccess.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int JobId { get; set; }
        public Job Job{ get; set; }

        public ICollection<ImprovementFeedback> ImprovementFeedbacks { get; set; }
    }
}
