using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedDate = DateTime.UtcNow;
        }
    }
}
