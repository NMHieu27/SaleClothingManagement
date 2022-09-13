using SaleClothingManagement.Common.DAL;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleClothingManagement.DAL
{
    public class BillDetailRep:GenericRep<ClothingShopContext, BillDetail>
    {
        public List<BillDetail> GetAllByBillID(int id)
        {
            return All.Where(c=>c.BillId==id).ToList();
        }
		
		public List<BillDetail> GetAllByProductID(int id)
        {
            return All.Where(c=>c.ProductId==id).ToList();
        }
		
		public List<BillDetail> GetAllBillDetail()
        {
            var res = All.ToList();
            return res;
        }
		
		public BillDetail GetBillDetail(int billId, int productId)
        {
            var res = All.FirstOrDefault(bd => bd.BillId == billId && bd.ProductId == productId);
            return res;
        }
		
		public SingleRsp DeleteBillDetail(int BillId, int ProductId)
        {
			var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.BillDetails.Remove(context.BillDetails.FirstOrDefault(bd => (bd.BillId == BillId && bd.ProductId == ProductId)));
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
		
		public SingleRsp CreateBillDetail(BillDetail billDetail)
		{
			var res = new SingleRsp();
			using (var context = new ClothingShopContext())
			{
				using (var tran = context.Database.BeginTransaction())
				{
					try
					{
						var c = context.BillDetails.Add(billDetail);
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
		
		public SingleRsp UpdateBillDetail(BillDetail billDetail)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.BillDetails.Update(billDetail);
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
		
    }
}
