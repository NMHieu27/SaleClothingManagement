﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req.ModelReq
{
    public class SearchDiscountReq
    {
        public string keyword { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }
}
