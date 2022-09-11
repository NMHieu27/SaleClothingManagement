using SaleClothingManagement.Common.BLL;
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
        BillRep req = new BillRep();
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
        public BillSvc() { }

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
                res = req.CreateBill(bill);
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
                    bill.EmployeeId = billReq.EmployeeId;
                    bill.CustumerId = billReq.CustumerId;
                    bill.CreatedDate = billReq.CreatedDate;
                    bill.Active = billReq.Active;
                    res = req.UpdateBill(bill);
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

        public object SearchBill(SearchBillReq searchBillReq)
        {
           
            var Bills = All.Where(e => e.CustumerId == searchBillReq.CustumerId);
            var offset = (searchBillReq.Page - 1) * searchBillReq.Size;
            var total = Bills.Count();
            int totalPage = (total % searchBillReq.Size) == 0 ? (int)(total / searchBillReq.Size) :
                (int)(1 + (total / searchBillReq.Size));
            var data = Bills.OrderBy(x => x.BillId).Skip(offset).Take(searchBillReq.Size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPage,
                Page = searchBillReq.Page,
                Size = searchBillReq.Size

            };

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
    }
}

