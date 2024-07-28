using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [PrimaryKey(nameof(CustomerId), nameof(ProductId))]
    public class CustomerProduct
    {
        [Column(Order = 0)]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
