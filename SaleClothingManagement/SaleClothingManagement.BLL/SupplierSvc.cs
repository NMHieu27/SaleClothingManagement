using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.Req.SupplierReq;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleClothingManagement.BLL
{
    public class SupplierSvc : GenericSvc<SupplierRep, Supplier>
    {
        private SupplierRep supplierRep = new SupplierRep();

        public SupplierSvc()
        {
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var data = _rep.Read(id);
            
            if (data != null)
            {
                res.Data = data;
                return res;
            }
            else
                return null;
        }

        public SingleRsp FindWithConditions(Dictionary<string, string> param)
        {
            var res = new SingleRsp();
            var data = supplierRep.FindByConditions(param);
            if (data.Count() == 0)
                res.Data = null;
            else
                res.Data = data;

            return res;
        }

        public SingleRsp StatCountryCount()
        {
            var res = new SingleRsp();
            res.Data = _rep.StatCountryCount();
            return res;
        }

        public SingleRsp StatProductCount()
        {
            var res = new SingleRsp();
            res.Data = _rep.StatProductCount();
            return res;
        }

        public SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res = _rep.Delete(id);
            return res;
        }

        public SingleRsp Create(SupplierReqCreate supplierReqCreate)
        {
            var res = new SingleRsp();
            Supplier supplier = new Supplier();

            supplier.Name = supplierReqCreate.Name;
            supplier.Phone = supplierReqCreate.Phone;
            supplier.Country = supplierReqCreate.Country;
            supplier.Description = supplierReqCreate.Description;

            res = _rep.Create(supplier);
            return res;
        }

        public SingleRsp Update(Supplier supplier)
        {
            var res = new SingleRsp();

            res = _rep.Update(supplier);
            return res;
        }

        public SingleRsp Update(SupplierReqUpdate supplierReqUpdate)
        {
            var res = new SingleRsp();
            Supplier supplier = new Supplier();

            supplier.Name = supplierReqUpdate.Name;
            supplier.Phone = supplierReqUpdate.Phone;
            supplier.Country = supplierReqUpdate.Country;
            supplier.Description = supplierReqUpdate.Description;

            res = _rep.Update(supplier);
            return res;
        }

    }
}
