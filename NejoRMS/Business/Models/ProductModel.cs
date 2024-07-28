using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, ErrorMessage = "{0} must be maximum {1} characters!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "{0} is required!")]
        public decimal Price { get; set; }
        public DateTime? Date { get; set; }
        [DisplayName("Quantity")]
        public string QunatityOutput { get; set; }
        [DisplayName("Price")]
        public string PriceOutput { get; set; }
        [DisplayName("Date")]
        public string DateOutput { get; set; }

    }
}
