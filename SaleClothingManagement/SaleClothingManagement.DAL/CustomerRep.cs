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

        public SingleRsp ProspectCustomer(int top, int month, int year)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                var prospectCustomer = (from bd in context.BillDetails
                                        where
                                          bd.Bill.CreatedDate.Value.Month == month &&
                                          bd.Bill.CreatedDate.Value.Year == year
                                        group new
                                        {
                                            bd.Bill.Custumer,
                                            bd.Bill,
                                            bd
                                        } by new
                                        {
                                            bd.Bill.Custumer.CustomerId,
                                            bd.Bill.Custumer.Fullname,
                                            Month = (int?)bd.Bill.CreatedDate.Value.Month,
                                            Year = (int?)bd.Bill.CreatedDate.Value.Year
                                        } into g
                                        orderby
                                          g.Sum(p => p.bd.Total) descending
                                        select new
                                        {
                                            g.Key.CustomerId,
                                            g.Key.Fullname,
                                            So_luong_san_pham_mua = (int?)g.Sum(p => p.bd.Amount),
                                            Tong_tien = (double?)g.Sum(p => p.bd.Total),
                                            Thang = g.Key.Month,
                                            Nam = g.Key.Year
                                        }).Take(top).ToList();
                res.Data = prospectCustomer;
            }
            return res;
        }
    }
}
