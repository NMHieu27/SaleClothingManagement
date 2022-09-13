using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req
{
    public class SearchCustomerReq
    {
        public string Keyword { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
