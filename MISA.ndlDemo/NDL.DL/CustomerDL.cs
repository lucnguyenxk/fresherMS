using NDL.Common.Entities;
using System;
using System.Collections.Generic;
using Dapper;
using MySqlConnector;
using System.Data;

namespace NDL.DL
{
    public class CustomerDL : BaseDl<Customer>, ICustomerDL
    {
    }
}
