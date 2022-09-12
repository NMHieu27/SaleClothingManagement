using SaleClothingManagement.DAL;
using SaleClothingManagement.Common.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using SaleClothingManagement.DAL.Models;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Req.DiscountReq;
using System.Linq;

namespace SaleClothingManagement.BLL
{
    public class DiscountSvc : GenericSvc<DiscountRep, Discount>
    {
        public DiscountSvc() { 
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res = _rep.Remove(id);
            return res;
        }

        public SingleRsp Create(DiscountReqCreate discountReq) { 
            var res = new SingleRsp();
            Discount discount = new Discount();

            discount.Name = discountReq.Name;
            discount.Value = discountReq.Value;
            discount.CreatedDate = DateTime.Now;
            discount.FromDate = discountReq.FromDate;
            discount.ToDate = discountReq.ToDate;
            res = _rep.Create(discount);

            return res;
        }

        public SingleRsp Update(DiscountReqUpdate discountReq) { 
            var res = new SingleRsp();
            Discount discount = new Discount();

            discount.DiscountId = discountReq.DiscountId;
            discount.Name = discountReq.Name;
            discount.Value = discountReq.Value;
            discount.FromDate = discountReq.FromDate;
            discount.ToDate = discountReq.ToDate;
            discount.Active = discountReq.Active;

            res = _rep.Update(discount);
            return res;
        }

        public SingleRsp SearchDiscount(SearchDiscountReq search) { 
            var res = new SingleRsp();
            var discounts = _rep.SearchDiscount(search.keyword);
            int discountCount, totalPages, offset;

            offset = search.size * (search.page - 1);
            discountCount = discounts.Count;
            totalPages = (discountCount % search.size) == 0 ?
                discountCount / search.size : 
                1 + (discountCount / search.size);
            
            var cus = new { 
                Data = discounts.Skip(offset).Take(search.size).ToList(),
                Page = search.page,
                Size = search.size
            } ;
            res.Data = cus;
            return res;
        }

        public SingleRsp CountProductByCategory() { 
            var res = new SingleRsp();
            res = _rep.CountBillHasDiscount();
            return res;
        }
    }
}
