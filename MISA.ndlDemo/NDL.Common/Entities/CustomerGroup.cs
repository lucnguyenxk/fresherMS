using NDL.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.Common.Entities
{
    public class CustomerGroup
    {
        public Guid CustomerGroupId { get; set; }
        [NdlRequired("Tên nhóm khách hàng không được bỏ trống!")]
        [NdlDuplicate("Tên nhóm khách hàng đã tồn tại!")]
        public string CustomerGroupName { get; set; }

        //[NdlRequired("Hãy viết gì đó cho phần mô tả!")]
       // public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
