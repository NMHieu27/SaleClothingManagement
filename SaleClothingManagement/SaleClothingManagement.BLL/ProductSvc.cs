using SaleClothingManagement.DAL;
using SaleClothingManagement.Common.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using SaleClothingManagement.DAL.Models;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Req.ModelReq;

namespace SaleClothingManagement.BLL
{
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep = new ProductRep();
        public ProductSvc()
        {
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp FindWithConditions(Dictionary<string, string> param)
        {
            var res = new SingleRsp();
            res.Data = productRep.FindByConditions(param);
            return res;
        }

        public SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res = _rep.Remove(id);
            return res;
        }

        public SingleRsp Create(ProductReqCreate productReqCreate)
        {
            var res = new SingleRsp();
            Product product = new Product();

            product.Name = productReqCreate.Name;
            product.Price = productReqCreate.Price;
            product.Remaining = productReqCreate.Remaining;
            product.CategoryId = productReqCreate.CategoryId;
            product.SupplierId = productReqCreate.SupplierId;

            res = _rep.Create(product);
            return res;
        }

        public SingleRsp Update(Product product)
        {
            var res = new SingleRsp();

            res = _rep.Update(product);
            return res;
        }

        public SingleRsp Update(ProductReqUpdate productReqUpdate)
        {
            var res = new SingleRsp();
            Product product = new Product();

            product.Name = productReqUpdate.Name;
            product.Price = productReqUpdate.Price;
            product.Remaining = productReqUpdate.Remaining;
            product.CategoryId = productReqUpdate.CategoryId;
            product.SupplierId = productReqUpdate.SupplierId;

            res = _rep.Update(product);
            return res;
        }
    }
}
