using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ImprovementModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        [DisplayName("Improvement Description")]
        public string Description { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentOutput { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeOutput { get; set; }

        public DateTime ImprovementDate { get; set; }
        public string ImprovementType { get; set; }

        public int Rating { get; set; }
    }
}
