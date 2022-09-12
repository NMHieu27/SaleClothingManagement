using SaleClothingManagement.Common.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SaleClothingManagement.Common.Rsp;

namespace SaleClothingManagement.DAL
{
    public class CategoryRep : GenericRep<ClothingShopContext, Category>
    {
        public CategoryRep() { 
        }

        public override Category Read(int id)
        {
            var res = base.All.FirstOrDefault(c => c.CategoryId == id);
            return res;
        }

        public SingleRsp Remove(int id) { 
            var res = new SingleRsp();
            using (var context = new ClothingShopContext()) {
                using (var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var category = context.Categories.First(c => c.CategoryId == id);
                        context.Categories.Remove(category);
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex) {
                        trans.Rollback();
                        res.SetError(ex.StackTrace);
                        var newContext = new ClothingShopContext();
                        var category = newContext.Categories.FirstOrDefault(c => c.CategoryId == id);
                        category.Active = false;
                        newContext.SaveChanges();
                    }
                }
            }
            return res;
        }

        public SingleRsp Create(Category category)
        {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext())
            {
                using (var trans = context.Database.BeginTransaction())
                {
                    try 
                    { 
                    
                        context.Categories.Add(category);
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

        public SingleRsp Update(Category category) {
            var res = new SingleRsp();
            using (var context = new ClothingShopContext()) {
                using (var trans = context.Database.BeginTransaction())
                {
                    try {
                        context.Categories.Update(category);
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex) { 
                        trans.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public List<Category> SearchCategory(string keyword) {
            return All.Where(c => c.Name.Contains(keyword)).ToList();
        }

        public SingleRsp CountProductByCategory() { 
            var res = new SingleRsp();
            var value = (from p in Context.Products
                         group new { p.Category, p } by new
                         {
                             p.Category.Name
                         } into g
                         orderby
                           g.Count(p => p.p.ProductId != null)
                         select new
                         {
                             Products_count = g.Count(p => p.p.ProductId != null),
                             Category_Name = g.Key.Name
                         }).ToList();
            res.Data = value;
            return res;
        }
    }
}
