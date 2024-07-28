using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<ImprovementFeedback> ImprovementFeedbacks { get; set; }
    }
}
