using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string QRCode { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime TrialEndDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
