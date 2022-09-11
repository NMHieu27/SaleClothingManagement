using SaleClothingManagement.Common.DAL;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleClothingManagement.DAL
{
    public class EmployeeRep : GenericRep< ClothingShopContext, Employee>
    {
        #region -- Overrides --
        public override Employee Read(int id)
        {
            var res = All.FirstOrDefault(e => e.EmployeeId == id);
            return res;
        }

        #endregion

        #region -- Methods --

        public SingleRsp CreateEmployee(Employee employee)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Employees.Add(employee);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateEmployee(Employee employee)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Employees.Update(employee);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteEmployee(int id)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Employees.Remove(context.Employees.FirstOrDefault(e=> e.EmployeeId == id));
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError("Warning","Can not hard delete --> soft delete (set active = false)");
                        var newContext = new ClothingShopContext();
                        var em = newContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
                        em.Active = false;
                        newContext.SaveChanges();
                    }
                }
            }
            return res;
        }

        
        #endregion
    }
}
