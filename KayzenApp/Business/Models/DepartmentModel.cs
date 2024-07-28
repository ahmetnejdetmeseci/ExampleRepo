using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Departman Adı")]
        public string Name { get; set; }

        public int CompanyId { get; set; }

        #region Extras
        [DisplayName("Şirket")]
        public string ComanyOutput { get; set; }

        [DisplayName("Employees")]
        public List<int> EmployeeIdsInput { get; set; }

        [DisplayName("Employees")]
        public string EmployeeOutput { get; set; }

        [DisplayName("Improvements")]
        public List<int> ImprovementsIdsInput { get; set; }

        [DisplayName("Improvements")]
        public string ImprovementOutput { get; set; }

        #endregion

    }
}
