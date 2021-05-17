using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NDL.Common.Entities;
using NDL.SV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ndlDemo.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : BaseController<Employee>
    {
        IEmployeeSV iEmp;
        public EmployeeController( IEmployeeSV baseSV ,IEmployeeSV _iEmp) : base(baseSV)
        {
            iEmp = _iEmp;
        }
        public override string getNewCode()
        {
            var result = iEmp.GetNewCode();
            return result;

        }

    }
}
