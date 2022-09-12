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
    public class ProductRep : GenericRep<ClothingShopContext, Product>
    {
        public ProductRep()
        {
        }

        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }

        public List<Product> FindBySupplierID(int id)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var products = context.Products.Where(p => p.SupplierId == id).ToList();

                        return products;
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

        public List<Product> FindByConditions(Dictionary<string, string> param)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<Func<Product, bool>> funcs = ProductSpecification.GetListCondition(param);

                        var products = context.Products.ToList();
                        foreach (var func in funcs)
                        {
                            products = products.Where(func).ToList();
                        }

                        return products;
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
                        context.Remove(context.Products.FirstOrDefault(p => p.ProductId == id));
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

        public SingleRsp Create(Product product)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Add(product);
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

        public SingleRsp Update(Product product)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Update(product);
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

        public Dictionary<string, string> StatRemaining()
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var products = context.Products.ToList();
                        Dictionary<string, string> result = new Dictionary<string, string>();

                        var amountOutOfStock = products.Where(s => s.Remaining == 0).Count();
                        result.Add("out_of_stock", amountOutOfStock.ToString());

                        var amountInStock = products.Where(s => s.Remaining != 0).Count();
                        result.Add("in_stock", amountInStock.ToString());

                        return result;
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

    }
}
