using NDL.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.Common.Entities
{
    public class Customer
    {
        /// <summary>
        /// Thông tin khách hàng 
        /// Creat by ndl
        /// </summary>
        public Guid CustomerId { get; set; }

        [NdlRequired("Mã khách hàng không được bỏ trống")]
        [NdlDuplicate("Mã khách hàng đã tồn tại!")]
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string MemberCode { get; set; }
        public Guid? CustomerGroupId { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public long TotalRecord { get; set; }

    }

}
