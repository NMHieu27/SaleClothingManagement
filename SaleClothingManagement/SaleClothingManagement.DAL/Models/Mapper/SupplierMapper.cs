using SaleClothingManagement.Common.Req.ModelReq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleClothingManagement.DAL.Models.Mapper
{
    public class SupplierMapper
    {
        public static Supplier ToSupplier(SupplierReqCreate supplierReqCreate)
        {
            Supplier supplier = new Supplier
            {
                Name = supplierReqCreate.Name,
                Phone = supplierReqCreate.Phone,
                Country = supplierReqCreate.Country,
                Description = supplierReqCreate.Description
            };

            return supplier;
        }

        public static Supplier ToSupplier(SupplierReqUpdate supplierReqUpdate)
        {
            Supplier supplier = new Supplier
            {
                Name = supplierReqUpdate.Name,
                Phone = supplierReqUpdate.Phone,
                Country = supplierReqUpdate.Country,
                Description = supplierReqUpdate.Description
            };

            return supplier;
        }

        public static SupplierReqUpdate ToSupplierReqUpdate(Supplier supplier)
        {
            SupplierReqUpdate supplierReqUpdate = new SupplierReqUpdate
            {
                Name = supplier.Name,
                Phone = supplier.Phone,
                Country = supplier.Country,
                Description = supplier.Description
            };

            return supplierReqUpdate;
        }

    }
}
