using System;
using System.Collections.Generic;

#nullable disable

namespace API_JWT.Models
{
    public partial class Product
    {
        public Product()
        {
            SalesDetails = new HashSet<SalesDetail>();
        }

        public int IdProducts { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
