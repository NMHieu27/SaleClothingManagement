using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req.BillReq
{
    public class BillReq
    {
        public int BillId { get; set; }
        public int CustumerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Active { get; set; }
    }
}
