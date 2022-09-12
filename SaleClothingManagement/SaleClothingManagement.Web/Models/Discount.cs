using System;
using System.Collections.Generic;

#nullable disable

namespace SaleClothingManagement.Web.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Categories = new HashSet<Category>();
        }

        public int DiscountId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
