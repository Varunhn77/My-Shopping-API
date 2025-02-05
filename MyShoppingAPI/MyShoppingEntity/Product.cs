using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShoppingEntity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        //[Required] - its for validation       // Data Annotation - we can enable primary key columns and configure validations
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
    }
}
