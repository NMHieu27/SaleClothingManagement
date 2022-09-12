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
        public List<Bill> ReadAllBills()
        {
            return All.ToList();
        }

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
                    catch (Exception)
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

        public List<Bill> SearchBill(int customerID)
        {
            return All.Where(b => b.CustumerId == customerID).ToList();
        }

        public SingleRsp TopBill(int top, int month, int year)
        {
            var res = new SingleRsp();
            using( var context = new ClothingShopContext())
            {
                var topBills = (from BillDetail in context.BillDetails
                                where
                                  BillDetail.Bill.CreatedDate.Value.Month == month &&
                                  BillDetail.Bill.CreatedDate.Value.Year == year
                                group new { BillDetail.Bill, BillDetail.Bill.Employee, BillDetail.Bill.Custumer, BillDetail } by new
                                {
                                    BillDetail.Bill.BillId,
                                    BillDetail.Bill.Employee.FirstName,
                                    BillDetail.Bill.Custumer.Fullname,
                                    Month = (int?)BillDetail.Bill.CreatedDate.Value.Month,
                                    Year = (int?)BillDetail.Bill.CreatedDate.Value.Year
                                } into g
                                orderby
                                  g.Sum(p => p.BillDetail.Total) descending
                                select new
                                {
                                    g.Key.BillId,
                                    Nhan_vien_ban = g.Key.FirstName,
                                    Khach_hang = g.Key.Fullname,
                                    Thang = g.Key.Month,
                                    Nam = g.Key.Year,
                                    Tong_so_luong_san_pham = (int?)g.Sum(p => p.BillDetail.Amount),
                                    Tong_tien = (double?)g.Sum(p => p.BillDetail.Total)
                                }).Take(top).ToList();
                res.Data = topBills;
            }
            return res;
        }
        #endregion
    }
}
