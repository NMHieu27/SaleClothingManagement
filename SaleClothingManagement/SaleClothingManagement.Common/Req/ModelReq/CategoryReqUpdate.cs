using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req.ModelReq
{
    public class CategoryReqUpdate
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? DiscountId { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
    }
}
