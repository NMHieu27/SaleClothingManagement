using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleClothingManagement.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Req.ModelReq;
using SaleClothingManagement.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleClothingManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;

        public CategoryController() {
            categorySvc = new CategorySvc();
        }

        [HttpGet("Get-All")]
        public IActionResult ReadAll() {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }

        [HttpPost("Get-By-Id")]
        public IActionResult GetCategoryById([FromBody] SimpleReq simpleReq) {
            var res = new SingleRsp();
            res = categorySvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveCategoryById([FromBody] SimpleReq simpleReq) {
            var res = new SingleRsp();
            res = categorySvc.Remove(simpleReq.Id);
            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPost("Create")]
        public IActionResult CreateCategory([FromBody] CategoryReqCreate categoryReq) {
            var res = new SingleRsp();
            res = categorySvc.Create(categoryReq);
            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPost("Update")]
        public IActionResult UpdateCategory([FromBody] CategoryReqUpdate categoryReq) {
            var res = new SingleRsp();
            res = categorySvc.Update(categoryReq);
            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPost("Search-Category")]
        public IActionResult SearchCategory([FromBody] SearchCategoryReq search) {
            var res = new SingleRsp();
            res = categorySvc.SearchCategory(search);
            return Ok(res);
        }

        [HttpPost("Stats-Category")]
        public IActionResult CountProductsByCategory() { 
            var res = new SingleRsp();
            res = categorySvc.CountProductByCategory();
            return Ok(res);
        }
    }
}
