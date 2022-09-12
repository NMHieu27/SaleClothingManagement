using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req.CategoryReq
{
    public class CategoryReqCreate
    {
        public string Name { get; set; }
        public int? DiscountId { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
    }
}
