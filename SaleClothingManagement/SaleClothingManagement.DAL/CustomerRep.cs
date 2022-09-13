using SaleClothingManagement.Common.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SaleClothingManagement.Common.Rsp;

namespace SaleClothingManagement.DAL
{
    public class CustomerRep:GenericRep<ClothingShopContext, Customer>
    {
        public override Customer Read(int id)
        {
            var res = All.FirstOrDefault(c=>c.CustomerId==id);
            return res;
        }
		
		public List<Customer> GetAllCustomer()
        {
            var res = All.ToList();
            return res;
        }
		
		public SingleRsp DeleteCustomer(int id)
        {
			var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Customers.Remove(context.Customers.FirstOrDefault(c => c.CustomerId == id));
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        res.SetError("Warning","Can not hard delete --> soft delete (set active = false)");
                        var newContext = new ClothingShopContext();
                        var cus = newContext.Customers.FirstOrDefault(c => c.CustomerId == id);
                        cus.Active = false;
                        newContext.SaveChanges();
                    }
                }
            }
            return res;
        }
		
		public SingleRsp CreateCustomer(Customer customer)
		{
			var res = new SingleRsp();
			using (var context = new ClothingShopContext())
			{
				using (var tran = context.Database.BeginTransaction())
				{
					try
					{
						var c = context.Customers.Add(customer);
						context.SaveChanges();
						tran.Commit();
					}
					catch (Exception ex)
					{
						tran.Rollback();
						res.SetError(ex.StackTrace);
					}
				}
			}
			return res;
		}
		
		public SingleRsp UpdateCustomer(Customer customer)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Customers.Update(customer);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
		
		public List<Customer> SearchCustomer(string Keyword)
		{
			return All.Where(x => x.Fullname.Contains(Keyword)).ToList();
		}
    }
}
