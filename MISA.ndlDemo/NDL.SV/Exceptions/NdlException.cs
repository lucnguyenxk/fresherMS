using NDL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.SV.Exceptions
{
    public class NdlException<NdlEntities>:Exception
    {
        public NdlException(string msg) : base(msg)
        {
            //this.Data.Add(msg, entity);
        }
    }
}
