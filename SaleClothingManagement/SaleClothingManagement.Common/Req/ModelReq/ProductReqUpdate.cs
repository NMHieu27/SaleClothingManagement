using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req.ModelReq
{
    public class ProductReqUpdate
    {

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public int? Remaining { get; set; }

        public int CategoryId { get; set; }

        public int? SupplierId { get; set; }

    }
}
