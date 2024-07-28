using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(100, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(500, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Description { get; set; }
        public DateTime? Date { get; set; }

        [DisplayName("Price")]
        public string PriceOutput { get; set; }

        [DisplayName("Date")]
        public string DateOutput { get; set; }

        [DisplayName("Product Count")]
        public int ProductsCountOutput { get; set; }

        [DisplayName("Products")]
        public List<int> ProductIdsInput { get; set; }

        [DisplayName("Users")]
        public string ProductNamesOutput { get; set; }

    }
}
