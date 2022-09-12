using SaleClothingManagement.Common.DAL;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleClothingManagement.DAL
{
    public class DiscountRep : GenericRep<ClothingShopContext, Discount>
    {
        public DiscountRep() {
        }

        public override Discount Read(int id)
        {
            var res = All.FirstOrDefault(d => d.DiscountId == id);
            return res;
        }

        public SingleRsp Remove(int id) {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext()) {
                using (var trans = context.Database.BeginTransaction()) {
                    try
                    {
                        var discount = context.Discounts.FirstOrDefault(d => d.DiscountId == id);
                        context.Remove(discount);
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex) {
                        trans.Rollback();
                        res.SetError("Alert", "Can not Hard Del, Soft Del will be performed!!!");
                        var newContext = new ClothingShopContext();
                        var discount = newContext.Discounts.FirstOrDefault(d => d.DiscountId == id);
                        discount.Active = false;
                        newContext.SaveChanges();
                    }
                }
            }
            return res;
        }

        public SingleRsp Create(Discount discount) {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Add(discount);
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }

        public SingleRsp Update(Discount discount)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Update(discount);
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }

        public List<Discount> SearchDiscount(string keyword) {
            return All.Where(d => d.Name.Contains(keyword)).ToList();
        }

        public SingleRsp CountBillHasDiscount() {
            var res = new SingleRsp();
            var value = (from c in Context.Categories
                         group new { c.Discount, c } by new
                         {
                             c.Discount.Name
                         } into g
                         orderby
                           g.Count(p => p.c.CategoryId != null)
                         select new
                         {
                             Category_Count = g.Count(p => p.c.CategoryId != null),
                             g.Key.Name
                         }).ToList();
            res.Data = value;
            return res;
        }
    }
}
