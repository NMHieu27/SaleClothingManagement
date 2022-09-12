using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req.ModelReq
{
    public class DiscountReqUpdate
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? Active { get; set; }
    }
}
