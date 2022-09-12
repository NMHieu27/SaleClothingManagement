using SaleClothingManagement.Common.DAL;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL.Models;
using SaleClothingManagement.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleClothingManagement.DAL
{
    public class SupplierRep : GenericRep<ClothingShopContext, Supplier>
    {
        public SupplierRep()
        {
        }

        public override Supplier Read(int id)
        {
            var res = All.FirstOrDefault(s => s.SupplierId == id);
            return res;
        }

        public List<Supplier> FindByConditions(Dictionary<string, string> param)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<Func<Supplier, bool>> funcs = SupplierSpecification.GetListCondition(param);

                        var suppliers = context.Suppliers.ToList();
                        foreach (var func in funcs)
                        {
                            suppliers = suppliers.Where(func).ToList();
                        }
                        
                        return suppliers;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return null;
        }

        public SingleRsp Remove(int id)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Remove(context.Suppliers.FirstOrDefault(s => s.SupplierId == id));
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }

        public SingleRsp Create(Supplier supplier)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Add(supplier);
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }

        public SingleRsp Update(Supplier supplier)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Update(supplier);
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }
    }
}
