using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req
{
    public class DiscountReqCreate
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
