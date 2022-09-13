using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleClothingManagement.BLL
{
    public class CustomerSvc: GenericSvc<CustomerRep, Customer>
    {
		private CustomerRep customerRep;
        public CustomerSvc()
        {
			customerRep = new CustomerRep();
        }
		
        public override SingleRsp Read(int id)
        {
			var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
		
		public SingleRsp GetAllCustomer()
        {
			var res = new SingleRsp();
            res.Data = customerRep.GetAllCustomer();
            return res;
        }
		
		public object SearchCustomer(SearchCustomerReq searchCustomerReq)
        {
			var res1 = new SingleRsp();
			var customers = customerRep.SearchCustomer(searchCustomerReq.Keyword);
            int pCount, totalPages, offset;
            offset = searchCustomerReq.Size * (searchCustomerReq.Page - 1);
            pCount = customers.Count;
			totalPages = (pCount%searchCustomerReq.Size)==0? (int)(pCount / searchCustomerReq.Size): (int)(1 + (pCount/searchCustomerReq.Size));

            var res = new
            {
                Data = customers.Skip(offset).Take(searchCustomerReq.Size).ToList(),
				TotalPages = totalPages,
                Page = searchCustomerReq.Page+1,
				Size= searchCustomerReq.Size
            };
        
            return res;
        }
		
		public SingleRsp DeleteCustomer(int id)
		{
			var res = new SingleRsp();
            var cus = id > 0 ? _rep.Read(id): _rep.Read(id);
			if (cus == null)
            {
                res.SetError("EZ103", "Employee not exist");
            }
            else
            {
                res = _rep.DeleteCustomer(id);
            }
			return res;
		}

        public SingleRsp CreateCustomer(CustomerReq customerReq)
        {
            var res = new SingleRsp();
            Customer customer = new Customer();
            customer.Address = customerReq.Address;
            customer.Dob = customerReq.Dob;
            customer.Email = customerReq.Email;
            customer.Fullname = customerReq.Fullname;
            customer.Phone = customerReq.Phone;
            res = customerRep.CreateCustomer(customer);
            return res;
        }

        public SingleRsp UpdateCustomer(CustomerReq customerReq)
        {
            var res = new SingleRsp();
            var cus = customerReq.CustomerId > 0 ? _rep.Read(customerReq.CustomerId) : _rep.Read(customerReq.CustomerId);

            if (cus == null)
			{
				res.SetError("EZ103", "Employee not exist");
			}
			else
			{
				Customer customer = new Customer();
				customer.CustomerId = customerReq.CustomerId;
				customer.Address = customerReq.Address;
				customer.Dob = customerReq.Dob;
				customer.Email = customerReq.Email;
				customer.Fullname = customerReq.Fullname;
				customer.Phone = customerReq.Phone;
				res = customerRep.UpdateCustomer(customer);
			}
            return res;
        }
    }
}
