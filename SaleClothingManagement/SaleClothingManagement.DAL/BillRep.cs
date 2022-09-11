using SaleClothingManagement.Common.DAL;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleClothingManagement.DAL
{
    public class BillRep : GenericRep<ClothingShopContext, Bill>
    {
        #region -- Overrides --
        public override Bill Read(int id)
        {
            var res = All.FirstOrDefault(e => e.BillId == id);
            return res;
        }

        #endregion

        #region -- Methods --

        public SingleRsp CreateBill(Bill bill)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Bills.Add(bill);
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
        public SingleRsp UpdateBill(Bill bill)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Bills.Update(bill);
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

        public SingleRsp DeleteBill(int id)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Bills.Remove(context.Bills.FirstOrDefault(e => e.BillId == id));
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError("Warning", "Can not hard delete --> soft delete (set active = false)");
                        var newContext = new ClothingShopContext();
                        var em = newContext.Bills.FirstOrDefault(e => e.BillId == id);
                        em.Active = false;
                        newContext.SaveChanges();
                    }
                }
            }
            return res;
        }


        #endregion
    }
}
