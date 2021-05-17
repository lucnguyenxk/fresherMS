using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;
using NDL.SV;
using NDL.Common.Entities;
using System.Data.Common;
using NDL.SV.Exceptions;
using System.Xml;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.ndlDemo.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        ICustomerSV iCustomerSV;
        public CustomerController(ICustomerSV baseSV, ICustomerSV iCusSV) : base(baseSV)
        {
            iCustomerSV = iCusSV;
        }
        public override string getNewCode()
        {
            return iCustomerSV.GetNewCode();
        }
    }
}
