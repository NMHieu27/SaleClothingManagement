using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req
{
    public class EmployeeReq
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public string Avata { get; set; }
    }
}
