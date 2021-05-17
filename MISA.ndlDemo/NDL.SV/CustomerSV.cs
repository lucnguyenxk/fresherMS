using NDL.Common.Attributes;
using NDL.Common.Entities;
using NDL.DL;
using NDL.SV.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NDL.SV
{
    public class CustomerSV : BaseSV<Customer>,ICustomerSV
    {
        ICustomerDL _iCustomerDL;
        public CustomerSV(IBaseDL<Customer> baseDL, ICustomerDL customerDL) : base(baseDL)
        {
            _iCustomerDL = customerDL;
        }
        public override string GetNewCode()
        {
            string res = base.GetNewCode();
            res = "KH-" + res;
            return res;
        }


        //public IEnumerable<Customer> GetALL()
        //{
        //    CustomerDL customerDL = new CustomerDL();
        //    var customers = customerDL.getAll<Customer>();
        //    return customers;   
        //}
        //public IEnumerable<Customer> GetById(string customerId) 
        //{
        //    CustomerDL customerDL = new CustomerDL();
        //    var customer = customerDL.getById<Customer>(customerId);
        //    return customer;
        //}
        //public int InsertCustomer(Customer customer)
        //{
        //    checkInput(customer);
        //    // thực hiện lấy dữ liệu 
        //    CustomerDL customerDL = new CustomerDL();
        //    var res = customerDL.Insert<Customer>(customer);
        //    return res ;
        //}
        //public int putCus(Customer cus, string id)
        //{
        //    checkInput(cus);
        //    CustomerDL customer = new CustomerDL();
        //    var result = customer.Update<Customer>(cus, id);
        //    return result;
        //}
        //public int deleteCus(string id)
        //{
        //    CustomerDL customerDL = new CustomerDL();
        //    var ressult = customerDL.Delete<Customer>(id);
        //    return ressult;
        //}
        protected override void Validate(Customer cus)
        {
            base.Validate(cus);
            if (cus is Customer)
            { 
                var emailTemplate = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
                if (!Regex.IsMatch(cus.Email, emailTemplate))
                {
                    throw new NdlException<Customer>("Email không đúng định dạng");
                }
            }
        }
        //public IEnumerable<Customer> getCusPaging(int m_PageIndex, int m_PageSize)
        //{
        //    CustomerDL customerDL = new CustomerDL();
        //    var res = customerDL.getCusPaging(m_PageIndex, m_PageSize);
        //    return res;
        //}
    }
}
