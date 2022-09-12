using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleClothingManagement.BLL;
using SaleClothingManagement.Common.Req;
using SaleClothingManagement.Common.Req.EmployeeReq;
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
        [HttpGet("get-by-id")]
        public IActionResult getEmployeeById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = employeeSvc.Read(req.Id);
            return Ok(res);

        }

        [HttpGet("get-all")]
        public IActionResult getAllEmployee()
        {
            var res = new SingleRsp();
            res = employeeSvc.ReadAllEmployees();
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

        [HttpPost("search-employee-by-firstname")]
        public IActionResult SearchProduct([FromBody] SearchEmployeeReq searchEmployeeReq)
        {
            var res = new SingleRsp();
            res  = employeeSvc.SearchEmployee(searchEmployeeReq);
            return Ok(res);
        }

        [HttpPost("get-top-employee-by-month-year")]
        public IActionResult TopEmployee([FromBody] BaseStatsReq employeeStatsReq)
        {
            var res = new SingleRsp();
            res = employeeSvc.TopEmployee(employeeStatsReq);
            return Ok(res);
        }

    }
}
