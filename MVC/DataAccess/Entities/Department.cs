using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace DataAccess.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public ICollection<Job> Jobs { get; set; }
        public ICollection<Machine> Machines{ get; set; }
        public ICollection<Process> Processes { get; set; }
    }
}
