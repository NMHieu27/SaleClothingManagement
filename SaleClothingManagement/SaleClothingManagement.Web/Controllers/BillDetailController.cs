using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleClothingManagement.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleClothingManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
		private BillDetailSvc billDetailSvc;
		public BillDetailController()
		{
			billDetailSvc = new BillDetailSvc();
		}
		
		[HttpPost("get-by-bill-id")]
		public IActionResult GetAllByBillID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = billDetailSvc.GetAllByBillID(simpleReq.Id);
			return Ok(res);
		}
		
		[HttpPost("get-by-product-id")]
		public IActionResult GetAllByProductID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = billDetailSvc.GetAllByProductID(simpleReq.Id);
			return Ok(res);
		}
		
		[HttpGet("get-all")]
        public IActionResult GetAllBilldetail()
        {
            var res = new SingleRsp();
            res = billDetailSvc.GetAllBillDetail();
            return Ok(res);
        }
		
		
		[HttpDelete("delete-by-bill-id")]
		public IActionResult DeleteBilldetailById([FromBody] BillDetailDeleteReq b)
		{
			var res = new SingleRsp();
			res = billDetailSvc.DeleteBillDetail(b.BillId, b.ProductId);
			return Ok(res);
		}

        [HttpPost("create-billDetail")]
        public IActionResult CreateBilldetail([FromBody] BillDetailReq reqBilldetail)
        {
            var res = billDetailSvc.CreateBillDetail(reqBilldetail);
            return Ok(res);
        }

        [HttpPost("update-billDetail")]
        public IActionResult UpdateBilldetail([FromBody] BillDetailReq reqBilldetail)
        {
            var res = billDetailSvc.UpdateBillDetail(reqBilldetail);
            return Ok(res);
        }
    }
}
