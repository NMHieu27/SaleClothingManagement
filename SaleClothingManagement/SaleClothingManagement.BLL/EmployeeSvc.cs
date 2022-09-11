using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace SaleClothingManagement.BLL
{
    public class EmployeeSvc : GenericSvc<EmployeeRep, Employee>
    {
        EmployeeRep req = new EmployeeRep();
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
        public EmployeeSvc() { }

        public SingleRsp CreateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            Employee employee = new Employee();
            employee.FirstName = employeeReq.FirstName;
            employee.LastName = employeeReq.LastName;
            employee.Dob = employeeReq.Dob;
            employee.HireDate = employeeReq.HireDate;
            employee.Avatar = employeeReq.Avata;
            employee.Active = employeeReq.Active;
            res = req.CreateEmployee(employee);
            return res;
        }

        public SingleRsp UpdateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            var em = employeeReq.EmployeeId > 0 ? _rep.Read(employeeReq.EmployeeId) : _rep.Read(employeeReq.EmployeeId);
            if (em == null)
            {
                res.SetError("EZ103", "Employee not exist");
            }
            else
            {
                Employee employee = new Employee();
                employee.FirstName = employeeReq.FirstName;
                employee.LastName = employeeReq.LastName;
                employee.Dob = employeeReq.Dob;
                employee.HireDate = employeeReq.HireDate;
                employee.Avatar = employeeReq.Avata;
                employee.Active = employeeReq.Active;
                res = req.UpdateEmployee(employee);
            }
            return res;
        }

        public SingleRsp DeleteEmployee(int id)
        {
            var res = new SingleRsp();
            var em = id > 0 ? _rep.Read(id) : _rep.Read(id);
            if (em == null)
            {
                res.SetError("EZ103", "Employee not exist");
            }
            else
            {
                res = _rep.DeleteEmployee(id);
            }
            return res;
        }

        public object SearchEmployee (SearchEmployeeReq searchEmployeeReq)
        {
            //string conds = "x =>";
            //if (!string.IsNullOrEmpty(searchEmployeeReq.FirstName)){
            //    conds += conds.Contains("x =>") ? "x.FirstName.Contains(searchEmployeeReq.FirstName)" 
            //        : " && x.FirstName.Contains(searchEmployeeReq.FirstName)";
            //}
            //if (!string.IsNullOrEmpty(searchEmployeeReq.LastName))
            //{
            //    conds += conds.Contains("x =>") ? "x.LastName.Contains(searchEmployeeReq.LastName)" 
            //        : " && x.LastName.Contains(searchEmployeeReq.LastName)";
            //}
            //if (!string.IsNullOrEmpty(searchEmployeeReq.Dob.ToString()))
            //{
            //    conds += conds.Contains("x =>") ? "x.Dob.Year == searchEmployeeReq.Dob.Year "
            //        +"&& x.Dob.Month == searchEmployeeReq.Dob.Month && x.Dob.Day == searchEmployeeReq.Dob.Day"
            //        : " && x.Dob.Year == searchEmployeeReq.Dob.Year "
            //        + "&& x.Dob.Month == searchEmployeeReq.Dob.Month && x.Dob.Day == searchEmployeeReq.Dob.Day";
            //}
            //if (!string.IsNullOrEmpty(searchEmployeeReq.HireDate.ToString()))
            //{
            //    conds += conds.Contains("x =>") ? "x.HireDate.Year == searchEmployeeReq.HireDate.Year "
            //        + "&& x.HireDate.Month == searchEmployeeReq.HireDate.Month && x.HireDate.Day == searchEmployeeReq.HireDate.Day"
            //        : " && x.HireDate.Year == searchEmployeeReq.HireDate.Year "
            //        + "&& x.HireDate.Month == searchEmployeeReq.HireDate.Month && x.HireDate.Day == searchEmployeeReq.HireDate.Day";

            //}
            //if (searchEmployeeReq.Active.ToString() == "true" || searchEmployeeReq.Active.ToString() == "false")
            //{
            //    conds += conds.Contains("x =>") ? "x.Active == searchEmployeeReq.Active "
            //        : " && x.Active == searchEmployeeReq.Active";
            //}
            //var employees = All.Where(conds);

            var employees = All.Where(e => e.FirstName.Contains(searchEmployeeReq.FirstName));
            var offset = (searchEmployeeReq.Page - 1) * searchEmployeeReq.Size;
            var total = employees.Count();
            int totalPage = (total % searchEmployeeReq.Size) == 0 ? (int)(total / searchEmployeeReq.Size) :
                (int)(1 + (total / searchEmployeeReq.Size));
            var data = employees.OrderBy(x => x.EmployeeId).Skip(offset).Take(searchEmployeeReq.Size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPage,
                Page = searchEmployeeReq.Page,
                Size = searchEmployeeReq.Size

            };

            return res;


        }
        #endregion
    }
}
