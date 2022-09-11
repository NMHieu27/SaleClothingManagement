using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req
{
    public class SearchEmployeeReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public DateTime? Dob { get; set; }
        //public DateTime? HireDate { get; set; }
        //public bool? Active { get; set; }

    }
}
