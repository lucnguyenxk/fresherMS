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
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        public CustomerGroupController(ICustomerGroupSV baseSV) : base(baseSV)
        {

        }
    }
}
