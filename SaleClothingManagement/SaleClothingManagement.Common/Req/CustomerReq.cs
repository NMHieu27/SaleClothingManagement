using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req
{
    public class CustomerReq
    {
        public int CustomerId { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
    }
}
