using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleClothingManagement.BLL;
using SaleClothingManagement.Common.CustomerReq;
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
    public class CustomerController : ControllerBase
    {
		private CustomerSvc customerSvc;
		public CustomerController()
		{
			customerSvc = new CustomerSvc();
		}
		
		[HttpGet("get-all")]
        public IActionResult GetAllCustomer()
        {
            var res = new SingleRsp();
            res = customerSvc.GetAllCustomer();
            return Ok(res);
        }
		
		[HttpPost("search-customer")]
        public IActionResult SearchCustomer([FromBody] SearchCustomerReq searchCustomerReq)
        {
            var res = new SingleRsp();
            var customers = customerSvc.SearchCustomer(searchCustomerReq);
            res.Data = customers;
            return Ok(res);
        }
		
		[HttpPost("get-by-id")]
		public IActionResult GetCustomerByID([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = customerSvc.Read(simpleReq.Id);
			return Ok(res);
		}
		
		[HttpDelete("delete-by-id")]
		public IActionResult DeleteCustomerById([FromBody] SimpleReq simpleReq)
		{
			var res = new SingleRsp();
			res = customerSvc.DeleteCustomer(simpleReq.Id);
			if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);
		}

        [HttpPost("create-customer")]
        public IActionResult CreateCustomer([FromBody] CustomerReq reqCustomer)
        {
            var res = customerSvc.CreateCustomer(reqCustomer);
            if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);
        }

        [HttpPost("update-customer")]
        public IActionResult UpdateCustomer([FromBody] CustomerReq reqCustomer)
        {
            var res = customerSvc.UpdateCustomer(reqCustomer);
            if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);
        }

        [HttpPost("get-top-customer")]
        public IActionResult ProspectCustomer([FromBody] BaseStatsReq baseStatsReq)
        {
            var res = new SingleRsp();
            res = customerSvc.ProspectCustomer(baseStatsReq);
            return Ok(res);
        }
    }
}
