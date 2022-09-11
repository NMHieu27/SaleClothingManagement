using System;
using System.Collections.Generic;

#nullable disable

namespace SaleClothingManagement.DAL.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int CustumerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Active { get; set; }

        public virtual Customer Custumer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
