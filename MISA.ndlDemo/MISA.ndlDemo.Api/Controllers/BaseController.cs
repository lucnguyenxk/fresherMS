using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDL.Common.Entities;
using NDL.SV;
using NDL.SV.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ndlDemo.Api.Controllers
{
    [EnableCors("allowOrigins")]
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseController<NdlEntity> : ControllerBase
    {
        IBaseSV<NdlEntity> _iBaseSV;
        public BaseController(IBaseSV<NdlEntity> IbaseSV)
        {
            _iBaseSV = IbaseSV;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var entities = _iBaseSV.getAll();
                if (entities.Count() > 0)
                {
                    return Ok(entities);
                }
            }
            catch (NdlException<NdlEntity> e)
            {
                return BadRequest(e);
            }
            return NoContent();
        }
        [HttpGet("getPaging")]
        public IActionResult getPaging(int PageNumber, int PageSize, string SearchString)
        {
            var result = _iBaseSV.getPaging(PageNumber, PageSize, SearchString);
            return Ok(result);
        }
        [HttpGet("getNewCode")]
        public virtual string getNewCode()
        {
            var result = _iBaseSV.GetNewCode();
            return result;

        }
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _iBaseSV.getById(id);
            return Ok(result);

        }
        //public IActionResult GetPaging(); 

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] NdlEntity entity)
        {
            try
            {
                var entiInsert = _iBaseSV.Insert(entity);

                if (entiInsert > 0)
                {
                    return Ok(entiInsert);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (NdlException<NdlEntity> ex)
            {
                return StatusCode(400, ex.Message);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] NdlEntity e)
        {
            
            var result = _iBaseSV.Update(e, id);
            if (result > 0)
            {
                return Ok("update thành công!");
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        { 
            var result = _iBaseSV.Delete(id);
            if (result > 0)
            {
                return Ok("Đã xoá!");
            }
            else
            {
                return NoContent();
            }
        }
        //[HttpGet("Paging")]
        //public IActionResult GetPaging(int m_PageIndex, int m_PageSize)
        //{
        //    CustomerSV customerSV= new CustomerSV();
        //    var result = customerSV.getCusPaging(m_PageIndex, m_PageSize);
        //    if (result.Count() > 0)
        //    {
        //        return Ok(result);
        //    }
        //    else return NoContent();
        //}
    }
}

