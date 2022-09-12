using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleClothingManagement.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Req.BillReq;
using SaleClothingManagement.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleClothingManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillSvc billSvc;
        public BillController()
        {
            billSvc = new BillSvc();
        }
        [HttpGet("get-by-id")]
        public IActionResult getBillById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = billSvc.Read(req.Id);
            return Ok(res);

        }

        [HttpGet("get-all")]
        public IActionResult getAllBill()
        {
            var res = new SingleRsp();
            res = billSvc.ReadAllBills();
            return Ok(res);
        }

        [HttpDelete("delete-by-id")]
        public IActionResult DeleteBillById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = billSvc.DeleteBill(req.Id);
            if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);

        }

        [HttpPost("create-bill")]
        public IActionResult CreateBill([FromBody] BillReq reqBill)
        {
            var res = billSvc.CreateBill(reqBill);
            if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);
        }

        [HttpPost("update-bill")]
        public IActionResult UpdateEmployee([FromBody] BillReq reqBill)
        {
            var res = billSvc.UpdateBill(reqBill);
            if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);
        }

        [HttpPost("search-bill-by-customerid")]
        public IActionResult SearchProduct([FromBody] SearchBillReq searchBillReq)
        {
            var res = new SingleRsp();
            res = billSvc.SearchBill(searchBillReq);
            return Ok(res);
        }

        [HttpPost("get-top-bill-by-month-year")]
        public IActionResult TopEmployee([FromBody] BaseStatsReq billStatsReq)
        {
            var res = new SingleRsp();
            res = billSvc.TopBill(billStatsReq);
            return Ok(res);
        }
    }
}