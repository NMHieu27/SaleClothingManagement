using System;
using System.Collections.Generic;

#nullable disable

namespace SaleClothingManagement.DAL.Models
{
    public partial class BillDetail
    {
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public double? Total { get; set; }
        public int? Amount { get; set; }

        public virtual Product Product { get; set; }
    }
}
