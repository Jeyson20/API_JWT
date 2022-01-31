using System;
using System.Collections.Generic;

#nullable disable

namespace API_JWT.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SalesDetails = new HashSet<SalesDetail>();
        }

        public int IdSale { get; set; }
        public DateTime Date { get; set; }
        public int IdCustomer { get; set; }
        public decimal? Total { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
