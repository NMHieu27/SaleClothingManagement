using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
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
        public override SingleRsp Read(int id)
        {
			var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
    }
}
