using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
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


        public override SingleRsp Update(Employee m)
        {
            var res = new SingleRsp();

            var m1 = m.EmployeeId > 0 ? _rep.Read(m.EmployeeId) : _rep.Read(m.EmployeeId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        #endregion

        #region -- Methods --
        public EmployeeSvc() { }

        public SingleRsp CreateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            Employee employee = new Employee();
            employee.EmployeeId = employeeReq.EmployeeId;
            employee.FirstName = employeeReq.FirstName;
            employee.LastName = employeeReq.LastName;
            employee.Dob = employeeReq.Dob;
            employee.IdentityNumber = employeeReq.IdentityNumber;
            employee.HireDate = employeeReq.HireDate;
            employee.Avatar = employeeReq.Avata;
            res = req.CreateEmployee(employee);
            return res;
        }

        public SingleRsp UpdateEmployee(EmployeeReq employeeReq)
        {
            var res = new SingleRsp();
            Employee employee = new Employee();
            employee.EmployeeId = employeeReq.EmployeeId;
            employee.FirstName = employeeReq.FirstName;
            employee.LastName = employeeReq.LastName;
            employee.Dob = employeeReq.Dob;
            employee.IdentityNumber = employeeReq.IdentityNumber;
            employee.HireDate = employeeReq.HireDate;
            employee.Avatar = employeeReq.Avata;
            res = req.UpdateEmployee(employee);
            return res;
        }

        public SingleRsp DeleteEmployee(int id)
        {
            var res = new SingleRsp();
            res = _rep.DeleteEmployee(id);
            return res;
        }
        #endregion
    }
}
