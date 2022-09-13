using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.BillDetailReq;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleClothingManagement.BLL
{
    public class BillDetailSvc: GenericSvc<BillDetailRep, BillDetail>
    {
		private BillDetailRep billDetailRep;
        public BillDetailSvc()
        {
			billDetailRep = new BillDetailRep();
        }
		
        public SingleRsp GetAllByBillID(int id)
        {
			var res = new SingleRsp();
            res.Data = _rep.GetAllByBillID(id);
            return res;
        }
		
		public SingleRsp GetAllByProductID(int id)
        {
			var res = new SingleRsp();
            res.Data = _rep.GetAllByProductID(id);
            return res;
        }
		
		public SingleRsp GetAllBillDetail()
        {
			var res = new SingleRsp();
            res.Data = billDetailRep.GetAllBillDetail();
            return res;
        }
		
		public SingleRsp DeleteBillDetail(int BillId, int ProductId)
		{
			var res = new SingleRsp();
            res = _rep.DeleteBillDetail(BillId, ProductId);
			return res;
		}

        public SingleRsp CreateBillDetail(BillDetailReq billDetailReq)
        {
            var res = new SingleRsp();
			var context = new ClothingShopContext();
			var bill = context.Bills.FirstOrDefault(b => b.BillId == billDetailReq.BillId);
			var product = context.Products.FirstOrDefault(p => p.ProductId == billDetailReq.ProductId);
			if (bill == null)
			{
				res.SetError("EZ103", "Bill not exist");
			}
			else 
				if (product == null)
				{
					res.SetError("EZ103", "Product not exist");
				}
				else 
					if (product.Remaining < billDetailReq.Amount)
					{
						res.SetError("EZ103", "Product amount not enough");
					}
					else
					{
						BillDetail billDetail = new BillDetail();
						billDetail.BillId = billDetailReq.BillId;
						billDetail.ProductId = billDetailReq.ProductId;
						billDetail.Amount = billDetailReq.Amount;
						var category = context.Categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);						
						var discount = context.Discounts.FirstOrDefault(d => d.DiscountId == category.DiscountId);
						var total = discount.Value * billDetailReq.Amount;
						billDetail.Total = total;
						//billDetail.Total = billDetailReq.Total;
						res = billDetailRep.CreateBillDetail(billDetail);
					}
            return res;
        }

        public SingleRsp UpdateBillDetail(BillDetailReq billDetailReq)
        {
            var res = new SingleRsp();
			var bd = billDetailRep.GetBillDetail(billDetailReq.BillId, billDetailReq.ProductId);
			if (bd == null)
			{
				res.SetError("EZ103", "BillDetail not exist");
			}
			else
			{
				BillDetail billDetail = new BillDetail();
				billDetail.BillId = billDetailReq.BillId;
				billDetail.ProductId = billDetailReq.ProductId;
				billDetail.Amount = billDetailReq.Amount;
				billDetail.Total = billDetailReq.Total;
				res = billDetailRep.UpdateBillDetail(billDetail);	
			}
            return res;
        }
    }
}
