using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Improvement> Improvements { get; set; }
    }
}
