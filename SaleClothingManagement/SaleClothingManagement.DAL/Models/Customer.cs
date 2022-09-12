using System;
using System.Collections.Generic;

#nullable disable

namespace SaleClothingManagement.DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }

        public int CustomerId { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
