using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NdlRequired : Attribute 
    {
        public string MsgEr;
        public NdlRequired(string _MsgEr)
        {
            MsgEr = _MsgEr;
        }
    }
    public class NdlDuplicate: Attribute
    {
        public string MsgEr;
        public NdlDuplicate(string _MsgEr)
        {
            MsgEr = _MsgEr;
        }
    }
}
