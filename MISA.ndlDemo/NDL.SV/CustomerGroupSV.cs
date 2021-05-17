using NDL.Common.Entities;
using NDL.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.SV
{
    public class CustomerGroupSV : BaseSV<CustomerGroup>, ICustomerGroupSV
    {
        public CustomerGroupSV(ICustomerGroupDL baseDL) : base(baseDL)
        {
                
        }
    }
}
