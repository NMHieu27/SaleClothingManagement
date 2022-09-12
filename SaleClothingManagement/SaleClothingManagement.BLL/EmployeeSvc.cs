using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Req.EmployeeReq;
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
        EmployeeRep rep = new EmployeeRep();
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
        public SingleRsp ReadAllEmployees()
        {
            var res = new SingleRsp();
            res.Data = rep.ReadAllEmployees();
            return res;
        }

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
            res = rep.CreateEmployee(employee);
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
                employee.EmployeeId = employeeReq.EmployeeId;
                employee.FirstName = employeeReq.FirstName;
                employee.LastName = employeeReq.LastName;
                employee.Dob = employeeReq.Dob;
                employee.HireDate = employeeReq.HireDate;
                employee.Avatar = employeeReq.Avata;
                employee.Active = employeeReq.Active;
                res = rep.UpdateEmployee(employee);
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

        public SingleRsp SearchEmployee (SearchEmployeeReq searchEmployeeReq)
        {
            //string conds = "x =>";
            //if (!string.IsNullOrEmpty(searchEmployeeReq.FirstName))
            //{
            //    conds += conds.Length <= 5 ? "x.FirstName.Contains(searchEmployeeReq.FirstName)"
            //        : " && x.FirstName.Contains(searchEmployeeReq.FirstName)";
            //}
            //if (!string.IsNullOrEmpty(searchEmployeeReq.LastName))
            //{
            //    conds += conds.Length <= 5 ? "x.LastName.Contains(searchEmployeeReq.LastName)"
            //        : " && x.LastName.Contains(searchEmployeeReq.LastName)";
            //}
            //if (!string.IsNullOrEmpty(searchEmployeeReq.Dob.ToString()))
            //{
            //    conds += conds.Length <= 5 ? "x.Dob.Year == searchEmployeeReq.Dob.Year "
            //        + "&& x.Dob.Month == searchEmployeeReq.Dob.Month && x.Dob.Day == searchEmployeeReq.Dob.Day"
            //        : " && x.Dob.Year == searchEmployeeReq.Dob.Year "
            //        + "&& x.Dob.Month == searchEmployeeReq.Dob.Month && x.Dob.Day == searchEmployeeReq.Dob.Day";
            //}
            //if (!string.IsNullOrEmpty(searchEmployeeReq.HireDate.ToString()))
            //{
            //    conds += conds.Length <= 5 ? "x.HireDate.Year == searchEmployeeReq.HireDate.Year "
            //        + "&& x.HireDate.Month == searchEmployeeReq.HireDate.Month && x.HireDate.Day == searchEmployeeReq.HireDate.Day"
            //        : " && x.HireDate.Year == searchEmployeeReq.HireDate.Year "
            //        + "&& x.HireDate.Month == searchEmployeeReq.HireDate.Month && x.HireDate.Day == searchEmployeeReq.HireDate.Day";

            //}
            //if (searchEmployeeReq.Active.ToString() == "true" || searchEmployeeReq.Active.ToString() == "false")
            //{
            //    conds += conds.Length <= 5 ? "x.Active == searchEmployeeReq.Active "
            //        : " && x.Active == searchEmployeeReq.Active";
            //}
            //var employees = All.Where(conds);

            var res = new SingleRsp();
            var employees = rep.SearchEmployee(searchEmployeeReq.FirstName);

            int offset = (searchEmployeeReq.Page - 1) * searchEmployeeReq.Size;
            int eCount = employees.Count();
            int totalPage = (eCount % searchEmployeeReq.Size) == 0 ? (eCount / searchEmployeeReq.Size) :
                (1 + (eCount / searchEmployeeReq.Size));
            var e = new
            {
                Data = employees.OrderBy(x => x.EmployeeId).Skip(offset).Take(searchEmployeeReq.Size).ToList(),
                Page = searchEmployeeReq.Page,
                Size = searchEmployeeReq.Size
            };
            res.Data = e;
            return res;
        }

        public SingleRsp TopEmployee(BaseStatsReq baseStatsReq)
        {
            var res = new SingleRsp();
            res = rep.TopEmployee(baseStatsReq.Top, baseStatsReq.Month, baseStatsReq.Year);
            return res;
        }
        #endregion
    }
}
