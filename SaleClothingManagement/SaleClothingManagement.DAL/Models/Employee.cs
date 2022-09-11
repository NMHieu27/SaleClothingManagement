using System;
using System.Collections.Generic;

#nullable disable

namespace SaleClothingManagement.DAL.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Bills = new HashSet<Bill>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
