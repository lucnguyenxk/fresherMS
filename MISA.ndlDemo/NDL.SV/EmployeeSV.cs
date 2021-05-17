using NDL.Common.Entities;
using NDL.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.SV
{
    public class EmployeeSV : BaseSV<Employee>,IEmployeeSV
    {
        public EmployeeSV(IEmployeeDL baseDL) : base(baseDL)
        {
            
        }
        public override string GetNewCode()
        {
            string res = base.GetNewCode();
            res = "NV-" + res;
            return res;
        }
    }
}
