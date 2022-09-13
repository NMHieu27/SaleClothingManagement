using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.BillDetailReq
{
    public class BillDetailReq
    {
        public int BillId { get; set; }
        public int ProductId { get; set; }
        public double? Total { get; set; }
        public int? Amount { get; set; }
    }
}
