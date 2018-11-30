using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Product
    {
       //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public string Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, 100)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
