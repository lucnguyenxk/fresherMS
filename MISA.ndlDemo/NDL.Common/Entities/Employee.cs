using NDL.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.Common.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }

        [NdlRequired("Mã nhân viên không được bỏ trống")]
        [NdlDuplicate("Mã nhân viên đã tồn tại, vui lòng kiểm tra lại : ")]
        public string EmployeeCode { get; set; }
        public string Fullname { get; set; }
        public Guid DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string IdentityCardNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Note { get; set; }
        public long TotalRecord { get; set; }
        public string DepartmentName { get; set; }

    }

}
