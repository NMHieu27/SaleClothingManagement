using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.Common.Req.EmployeeReq
{
    public class EmployeeReq
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? HireDate { get; set; }
        public string Avata { get; set; }
        public bool? Active { get; set; }
    }
}
