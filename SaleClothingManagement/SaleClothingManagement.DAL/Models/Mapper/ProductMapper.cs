using SaleClothingManagement.Common.Req.ProductReq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.DAL.Models.Mapper
{
    public static class ProductMapper
    {
        public static Product ToProduct(ProductReqCreate productReqCreate)
        {

            Product product = new Product
            {
                Name = productReqCreate.Name,
                Price = productReqCreate.Price,
                Remaining = productReqCreate.Remaining,
                CategoryId = productReqCreate.CategoryId,
                SupplierId = productReqCreate.SupplierId
            };

            return product;
        }

        public static Product ToProduct(ProductReqUpdate productReqUpdate)
        {

            Product product = new Product
            {
                Name = productReqUpdate.Name,
                Price = productReqUpdate.Price,
                Remaining = productReqUpdate.Remaining,
                CategoryId = productReqUpdate.CategoryId,
                SupplierId = productReqUpdate.SupplierId
            };

            return product;
        }

        public static ProductReqUpdate ToProductReqUpdate(Product product)
        {
            ProductReqUpdate productReqUpdate = new ProductReqUpdate
            {
                Name = product.Name,
                Price = product.Price,
                Remaining = product.Remaining,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId
            };

            return productReqUpdate;
        }

    }
}
