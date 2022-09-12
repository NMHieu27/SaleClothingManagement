using SaleClothingManagement.Common.BLL;
using SaleClothingManagement.Common.Req.ModelReq;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL;
using SaleClothingManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SaleClothingManagement.BLL
{
    public class CategorySvc : GenericSvc<CategoryRep, Category> 
    {
        public CategorySvc() { }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp Remove(int id) { 
            var res = new SingleRsp();
            res = _rep.Remove(id);
            return res;
        }

        public SingleRsp Create(CategoryReqCreate categoryReq) { 
            var res = new SingleRsp();
            Category category = new Category();

            category.Name = categoryReq.Name;
            category.DiscountId = categoryReq.DiscountId;
            category.Description = categoryReq.Description;
            category.Active = categoryReq.Active;

            res = _rep.Create(category);
            return res;
        }

        public SingleRsp Update(CategoryReqUpdate categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();

            category.CategoryId = categoryReq.CategoryId;
            category.Name = categoryReq.Name;
            category.DiscountId = categoryReq.DiscountId;
            category.Description = categoryReq.Description;
            category.Active = categoryReq.Active;

            res = _rep.Update(category);
            return res;
        }

        public SingleRsp SearchCategory(SearchCategoryReq search) {
            var res = new SingleRsp();
            var categories = _rep.SearchCategory(search.keyword);
            int categoryCount, totalPages, offset;

            offset = search.size * (search.page - 1);
            categoryCount = categories.Count;
            totalPages = (categoryCount % search.size) == 0 ?
                categoryCount / search.size :
                1 + (categoryCount / search.size);

            var cus = new
            {
                Data = categories.Skip(offset).Take(search.size).ToList(),
                Page = search.page,
                Size = search.size
            };
            res.Data = cus;
            return res;
        }

        public SingleRsp CountProductByCategory() { 
            var res = new SingleRsp();
            res = _rep.CountProductByCategory();
            return res;
        }
    }
}
