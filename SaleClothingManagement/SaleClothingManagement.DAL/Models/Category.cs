using System;
using System.Collections.Generic;

#nullable disable

namespace SaleClothingManagement.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? DiscountId { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
