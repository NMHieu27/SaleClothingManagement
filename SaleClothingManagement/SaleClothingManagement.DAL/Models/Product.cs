using System;
using System.Collections.Generic;

#nullable disable

namespace SaleClothingManagement.DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Remaining { get; set; }
        public int CategoryId { get; set; }
        public int? SupplierId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
