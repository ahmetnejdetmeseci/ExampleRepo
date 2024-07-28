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
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(100, ErrorMessage = "{0} must be maximum {1} characters!")]

        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        public DateTime? Date { get; set; }


        [DisplayName("Product Count")]
        public int ProductsCountOutput { get; set; }

        [DisplayName("Products")]
        public List<int> ProductIdsInput { get; set; }

        [DisplayName("Users")]
        public string ProductNamesOutput { get; set; }


        [DisplayName("Customer Count")]
        public int CustomerCountOutput { get; set; }

        [DisplayName("Customers")]
        public List<int> CustomerIdsInput { get; set; }

        [DisplayName("Customers")]
        public string CustomerNamesOutput { get; set; }


    }
}
