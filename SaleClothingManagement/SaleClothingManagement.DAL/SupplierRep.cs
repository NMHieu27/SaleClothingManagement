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
        ProductRep productRep = new ProductRep();
        public SupplierRep()
        {
        }

        public override Supplier Read(int id)
        {
            Supplier res = All.FirstOrDefault(s => s.SupplierId == id);
            if (res != null)
            {
                res.Products = productRep.FindBySupplierID(id);
                return res;
            }

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

        public List<Dictionary<string, string>> StatCountryCount()
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var suppliers = context.Suppliers.ToList();
                        var countryList = suppliers.Select(s => s.Country).Distinct();
                        List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();

                        foreach (var country in countryList)
                        {
                            var count = suppliers.Where(s => s.Country.Equals(country)).Count();
                            Dictionary<string, string> record = new Dictionary<string, string>();
                            record.Add("country_name", country);
                            record.Add("number_of_suppliers", count.ToString());

                            resultList.Add(record);
                        }

                        return resultList;
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

        public List<Dictionary<string, string>> StatProductCount()
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var suppliers = context.Suppliers.ToList();
                        List<Dictionary<string, string>> resultList = new List<Dictionary<string, string>>();

                        foreach (var supplier in suppliers)
                        {
                            var count = Read(supplier.SupplierId).Products.Count();
                            Dictionary<string, string> record = new Dictionary<string, string>();
                            record.Add("supplier_id", supplier.SupplierId.ToString());
                            record.Add("supplier_name", supplier.Name.ToString());
                            record.Add("products_count", count.ToString());

                            resultList.Add(record);
                        }

                        return resultList;
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

        public SingleRsp Delete(int id)
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
