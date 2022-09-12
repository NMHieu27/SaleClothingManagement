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
        public List<Employee> ReadAllEmployees()
        {
            return All.ToList();
        }

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

        public List<Employee> SearchEmployee(string firstName)
        {
            return All.Where(e => e.FirstName.Contains(firstName)).ToList();
        }
        
        public SingleRsp TopEmployee(int top, int month, int year)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                //    var topEmployees = (from BillDetail in context.BillDetails
                //                        where
                //                      BillDetail.Bill.CreatedDate.Value.Month == month &&
                //                      BillDetail.Bill.CreatedDate.Value.Year == year
                //                        group new { BillDetail.Bill.Employee, BillDetail.Bill, BillDetail } by new
                //                        {
                //                            BillDetail.Bill.Employee.EmployeeId,
                //                            BillDetail.Bill.Employee.FirstName,
                //                            BillDetail.Bill.Employee.LastName,
                //                            Month = (int?)BillDetail.Bill.CreatedDate.Value.Month,
                //                            Year = (int?)BillDetail.Bill.CreatedDate.Value.Year
                //                        } into g
                //                        orderby
                //                          g.Sum(p => p.BillDetail.Total) descending
                //                        select new
                //                        {
                //                            g.Key.EmployeeId,
                //                            g.Key.FirstName,
                //                            g.Key.LastName,
                //                            Thang = g.Key.Month,
                //                            Nam = g.Key.Year,
                //                            doanh_thu = (double?)g.Sum(p => p.BillDetail.Total)
                //                        }).Take(top).ToList();
                //    res.Data = topEmployees;
                //}

                    var topEmployees = (from bd in context.BillDetails
                                        join b in context.Bills on bd.BillId equals b.BillId
                                        join e in context.Employees on b.EmployeeId equals e.EmployeeId
                                        where
                                      b.CreatedDate.Value.Month == month &&
                                      b.CreatedDate.Value.Year == year
                                        group new { e, b, bd } by new
                                        {
                                            e.EmployeeId,
                                            e.FirstName,
                                            e.LastName,
                                            Month = (int?)b.CreatedDate.Value.Month,
                                            Year = (int?)b.CreatedDate.Value.Year
                                        } into g
                                        orderby
                                          g.Sum(p => p.bd.Total) descending
                                        select new
                                        {
                                            g.Key.EmployeeId,
                                            g.Key.FirstName,
                                            g.Key.LastName,
                                            Thang = g.Key.Month,
                                            Nam = g.Key.Year,
                                            doanh_thu = (double?)g.Sum(p => p.bd.Total)
                                        }).Take(top).ToList();
                    res.Data = topEmployees;
            }
            return res;
        }
        #endregion
    }
}
