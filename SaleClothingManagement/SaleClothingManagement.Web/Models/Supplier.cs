using System;
using System.Collections.Generic;

#nullable disable

namespace SaleClothingManagement.Web.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
