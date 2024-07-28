using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Şirket Adı")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Kayıt Tarihi")]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [DisplayName("Deneme Sürümü Bitiş")]
        public DateTime TrialEndDate { get; set; }

        [DisplayName("Şirket Aktifliği")]
        public bool IsActive { get; set; }

        public List<Department> Departments { get; set; }

    }
}
