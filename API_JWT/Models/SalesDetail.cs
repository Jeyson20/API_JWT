using System;
using System.Collections.Generic;

#nullable disable

namespace API_JWT.Models
{
    public partial class SalesDetail
    {
        public int IdSalesD { get; set; }
        public int IdSale { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int IdProduct { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual Sale IdSaleNavigation { get; set; }
    }
}
