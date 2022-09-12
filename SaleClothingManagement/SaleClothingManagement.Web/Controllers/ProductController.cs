﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleClothingManagement.BLL;
using SaleClothingManagement.Common.Req.ModelReq;
using SaleClothingManagement.Common.Rsp;
using SaleClothingManagement.DAL.Models;
using SaleClothingManagement.DAL.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleClothingManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;

        public ProductController()
        {
            this.productSvc = new ProductSvc();
        }

        [HttpGet("find-all")]
        public IActionResult FindAll()
        {
            var res = new SingleRsp();

            try
            {
                var resultList = productSvc.All;

                if (resultList.Count() == 0)
                {
                    return NoContent();
                }
                else
                {
                    res.Data = productSvc.All;
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
            res = productSvc.Read(id);
            return Ok(res);
        }

        [HttpGet("find-by-conditions")]
        public IActionResult FindWithConditions([FromBody] Dictionary<string, string> param)
        {
            var res = new SingleRsp();
            res = productSvc.FindWithConditions(param);
            return Ok(res);
        }

        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody] ProductReqCreate productReqCreate)
        {
            var res = new SingleRsp();
            res = productSvc.Create(ProductMapper.ToProduct(productReqCreate));

            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct([FromBody] ProductReqUpdate productReqUpdate, int id)
        {
            var res = new SingleRsp();
            var resProduct = new SingleRsp();

            resProduct = productSvc.Read(id);

            Product product = new Product();
            product = ProductMapper.ToProduct(productReqUpdate);
            product.ProductId = id;

            res = productSvc.Update(product);

            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteByID(int id)
        {
            var res = new SingleRsp();
            res = productSvc.Delete(id);

            if (res.Success)
                return Ok(res);
            else
                return BadRequest(res);
        }

    }
}
