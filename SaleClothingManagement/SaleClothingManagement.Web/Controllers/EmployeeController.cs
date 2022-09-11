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
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeSvc employeeSvc;
        public EmployeeController()
        {
            employeeSvc = new EmployeeSvc();
        }
        [HttpPost("get-by-id")]
        public IActionResult getEmployeeById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = employeeSvc.Read(req.Id);
            return Ok(res);

        }

        [HttpPost("get-all")]
        public IActionResult getAllEmployee()
        {
            var res = new SingleRsp();
            res.Data = employeeSvc.All;
            return Ok(res);
        }

        [HttpDelete("delete-by-id")]
        public IActionResult DeleteEmployeeById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = employeeSvc.DeleteEmployee(req.Id);
            if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);

        }

        [HttpPost("create-employee")]
        public IActionResult CreateEmployee([FromBody] EmployeeReq reqEmployee)
        {
            var res = employeeSvc.CreateEmployee(reqEmployee);
            if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);
        }

        [HttpPost("update-employee")]
        public IActionResult UpdateEmployee([FromBody] EmployeeReq reqEmployee)
        {
            var res = employeeSvc.UpdateEmployee(reqEmployee);
            if (res.Success)
            {
                return Ok(res);
            }
            else
                return BadRequest(res);
        }

    }
}
