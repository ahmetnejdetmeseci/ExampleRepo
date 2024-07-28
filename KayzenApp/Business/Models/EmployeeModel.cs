using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Employee Name")]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(50)]
        public string PasswordSalt { get; set; }

        #region Extras
        [DisplayName("Department Name")]
        public string DepartmentOutput { get; set; }

        [DisplayName("Improvements")]
        public List<int> ImprovementIdsInput { get; set; }

        [DisplayName("Improvements")]
        public string ImprovementsOutput { get; set; }

        #endregion

    }
}
