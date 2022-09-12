using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleClothingManagement.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.Common.Req.DiscountReq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleClothingManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private DiscountSvc discountSvc;

        public DiscountController() {
            discountSvc = new DiscountSvc();
        }

        [HttpGet("Get-All")]
        public IActionResult ReadAll()
        {
            var res = new SingleRsp();
            res.Data = discountSvc.All;
            return Ok(res);
        }

        [HttpPost("Get-By-Id")]
        public IActionResult GetDiscountById([FromBody] SimpleReq simpleReq) {
            var res = new SingleRsp();
            res = discountSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteDiscount([FromBody] SimpleReq simpleReq) {
            var res = new SingleRsp();
            res = discountSvc.Delete(simpleReq.Id);
            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPost("Create")]
        public IActionResult CreateDiscount([FromBody] DiscountReqCreate discountReq)
        {
            var res = new SingleRsp();
            res = discountSvc.Create(discountReq);
            if(res.Success)
                return Ok(res);
            else 
                return BadRequest(res);
        }

        [HttpPost("Update")]
        public IActionResult UpdateDiscount([FromBody] DiscountReqUpdate discountReq)
        {
            var res = new SingleRsp();
            res = discountSvc.Update(discountReq);
            if (res.Success)
                return Ok(res);
            else 
                return BadRequest(res);
        }

        [HttpPost("Search-Discount")]
        public IActionResult SearchDiscount([FromBody] SearchDiscountReq search) { 
            var res = new SingleRsp();
            res = discountSvc.SearchDiscount(search);
            return Ok(res);
        }

        [HttpPost("Stats-Discount")]
        public IActionResult CountProductByCategory() {
            var res = new SingleRsp();
            res = discountSvc.CountProductByCategory();
            return Ok(res);
        }
    }
}
