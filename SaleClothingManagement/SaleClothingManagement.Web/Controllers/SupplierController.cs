using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleClothingManagement.BLL;
using SaleClothingManagement.Common.Req.SupplierReq;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL.Models;
using SaleClothingManagement.DAL.Models.Mapper;
using SaleClothingManagement.DAL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleClothingManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SupplierController : ControllerBase
    {
        private SupplierSvc supplierSvc;

        public SupplierController()
        {
            this.supplierSvc = new SupplierSvc();
        }

        [HttpGet("find-all")]
        public IActionResult FindAll()
        {
            var res = new SingleRsp();

            try
            {
                var resultList = supplierSvc.All;

                if (resultList.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    res.Data = supplierSvc.All;
                    return Ok(res);
                }
            }
            catch (Exception ex)
            {
                res.Data = ex;
                return BadRequest(res);
            }
        }

        [HttpGet("find/{id}")]
        public IActionResult FindByID(int id)
        {
            var res = new SingleRsp();
            res = supplierSvc.Read(id);

            if (res == null)
                return NoContent();
            else
                return Ok(res);
        }

        [HttpGet("find-by-conditions")]
        public IActionResult FindWithConditions([FromBody] Dictionary<string, string> param)
        {
            //var res = new SingleRsp();
            //res = supplierSvc.FindWithConditions(param);
            //return Ok(res);

            var res = new SingleRsp();

            List<Func<Supplier, bool>> funcs = SupplierSpecification.GetListCondition(param);
            if (funcs.Count() == 0)
            {
                res.Data = "Invalid match key parameter";
                return BadRequest(res);
            }

            res = supplierSvc.FindWithConditions(param);
            if (res.Data == null)
                return NoContent();

            return Ok(res);
        }

        [HttpPost("create")]
        public IActionResult CreateSupplier([FromBody] SupplierReqCreate supplierReqCreate)
        {
            var res = new SingleRsp();
            res = supplierSvc.Create(SupplierMapper.ToSupplier(supplierReqCreate));

            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateSupplier([FromBody] SupplierReqUpdate supplierReqUpdate, int id)
        {
            var res = new SingleRsp();
            var resSupplier = new SingleRsp();

            resSupplier = supplierSvc.Read(id);

            Supplier supplier = new Supplier();
            supplier = SupplierMapper.ToSupplier(supplierReqUpdate);
            supplier.SupplierId = id;

            res = supplierSvc.Update(supplier);

            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteByID(int id)
        {
            var res = new SingleRsp();

            try
            {
                res = supplierSvc.Delete(id);

                if (res.Success)
                    return Ok(res);
                else
                    return BadRequest(res);
            }
            catch (Exception ex)
            {
                res.Data = ex;
                return BadRequest(res);
            }

        }

        [HttpGet("stat/country-product-count")]
        public IActionResult StatCountryProductCount()
        {
            var res = new SingleRsp();
            res = supplierSvc.StatCountryCount();

            return Ok(res);
        }

        [HttpGet("stat/product-count")]
        public IActionResult StatProductCount()
        {
            var res = new SingleRsp();
            res = supplierSvc.StatProductCount();

            return Ok(res);
        }

    }
}
