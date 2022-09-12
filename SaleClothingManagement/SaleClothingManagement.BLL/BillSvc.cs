using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Req.BillReq;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleClothingManagement.BLL
{
    public class BillSvc : GenericSvc<BillRep, Bill>
    {
        BillRep rep = new BillRep();
        #region -- Overrides -- 
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        #endregion

        #region -- Methods --
        public SingleRsp ReadAllBills()
        {
            var res = new SingleRsp();
            res.Data = rep.ReadAllBills();
            return res;
        }

        public SingleRsp CreateBill(BillReq billReq)
        {
            var res = new SingleRsp();
            string errMsg = "";
            bool flag = true;
            if (!CheckCustomerExist(billReq.CustumerId))
            {
                flag = false;
                errMsg += " ID Customer not exist!";
            }
            if (!CheckEmployeeExist(billReq.EmployeeId))
            {
                flag = false;
                errMsg += " ID Employee not exist!";
            }
            if (flag)
            {
                Bill bill = new Bill();
                bill.EmployeeId = billReq.EmployeeId;
                bill.CustumerId = billReq.CustumerId;
                bill.CreatedDate = billReq.CreatedDate;
                bill.Active = billReq.Active;
                res = rep.CreateBill(bill);
            }
            else
            {
                res.SetError("EZ103", errMsg);
            }
            return res;
        }

        public SingleRsp UpdateBill(BillReq billReq)
        {
            var res = new SingleRsp();
            var em = billReq.BillId > 0 ? _rep.Read(billReq.BillId) : _rep.Read(billReq.BillId);
            if (em == null)
            {
                res.SetError("EZ103", "Bill not exist");
            }
            else
            {
                string errMsg = "";
                bool flag = true;
                if (!CheckCustomerExist(billReq.CustumerId))
                {
                    flag = false;
                    errMsg += " ID Customer not exist!";
                }
                if (!CheckEmployeeExist(billReq.EmployeeId))
                {
                    flag = false;
                    errMsg += " ID Employee not exist!";
                }
                if (flag)
                {
                    Bill bill = new Bill();
                    bill.BillId = billReq.BillId;
                    bill.EmployeeId = billReq.EmployeeId;
                    bill.CustumerId = billReq.CustumerId;
                    bill.CreatedDate = billReq.CreatedDate;
                    bill.Active = billReq.Active;
                    res = rep.UpdateBill(bill);
                }
                else
                {
                    res.SetError("EZ103", errMsg);
                }
            }
            return res;
        }

        public SingleRsp DeleteBill(int id)
        {
            var res = new SingleRsp();
            var em = id > 0 ? _rep.Read(id) : _rep.Read(id);
            if (em == null)
            {
                res.SetError("EZ103", "Bill not exist");
            }
            else
            {
                res = _rep.DeleteBill(id);
            }
            return res;
        }

        public SingleRsp SearchBill(SearchBillReq searchBillReq)
        {
            var res = new SingleRsp();
            var Bills = rep.SearchBill(searchBillReq.CustumerId);
            int offset = (searchBillReq.Page - 1) * searchBillReq.Size;
            int bCount = Bills.Count();
            int totalPage = (bCount % searchBillReq.Size) == 0 ?(bCount / searchBillReq.Size) :
                (1 + (bCount / searchBillReq.Size));
            var b = new
            {
                Data = Bills.OrderBy(x => x.BillId).Skip(offset).Take(searchBillReq.Size).ToList(),
                Page = searchBillReq.Page,
                Size = searchBillReq.Size

            };
            res.Data = b;
            return res;


        }
        #endregion
        public bool CheckCustomerExist(int id)
        {
            var context = new ClothingShopContext();
            var cus = context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (cus != null)
            {
                return true;
            }
            return false;
        }
        public bool CheckEmployeeExist(int id)
        {
            var context = new ClothingShopContext();
            var em = context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (em != null)
            {
                return true;
            }
            return false;
        }

        public SingleRsp TopBill(BaseStatsReq baseStatsReq)
        {
            var res = new SingleRsp();
            res = rep.TopBill(baseStatsReq.Top, baseStatsReq.Month, baseStatsReq.Year);
            return res;
        }
    }
}

