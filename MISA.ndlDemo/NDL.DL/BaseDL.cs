using Dapper;
using MySqlConnector;
using NDL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.DL
{
    public class BaseDl<NdlEntities>: IBaseDL<NdlEntities>
    {
        //1.khai báo thông tin kết nối với db
        protected string  _connectionString = "" +
                "Host= 47.241.69.179;" +
                "Port= 3306;" +
                "Database = 15B_MS2_CukCuk_NDLuc;" +
                "User Id = dev;" +
                "Password=12345678;" +
                "ConvertZeroDateTime=True ";

        // 2.khởi tạo kết nối
        protected IDbConnection dbConnection;
        public IEnumerable<NdlEntities> getAll()
        {
            using (dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(NdlEntities).Name;
                var SqlCommand = $"Proc_Get{name}s";
                var entities = dbConnection.Query<NdlEntities>(SqlCommand, commandType: CommandType.StoredProcedure);
                return entities;
            }
        }
        public int Insert(NdlEntities entity)
        {
            using (dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(NdlEntities).Name;
                var sqlCommand = $"Proc_Insert{name}";
                var res = dbConnection.Execute(sqlCommand, param:entity, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
        
        public NdlEntities getById(string entityId)
        {
            using (dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(NdlEntities).Name;
                var SqlCommand = $"Proc_Get{name}ById";
                var param = new DynamicParameters();
                param.Add($"@{name}Id", entityId);
                var result = dbConnection.QueryFirstOrDefault<NdlEntities>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return result;
            }

            
        }
        public int Update(NdlEntities entity, string id)
        {
            using (dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(NdlEntities).Name;
                var SqlCommand = $"Proc_Update{name}";
                var result = dbConnection.Execute(SqlCommand, param: entity, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public int Delete(string id)
        {
            using (dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(NdlEntities).Name;
                var SqlCommand = $"Proc_Delete{name}";
                var param = new DynamicParameters();
                param.Add($"@{name}Id", id);
                var result = dbConnection.Execute(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
                return result;
            }

        }
        public bool GetCodeExist(string  code, string typeCode)
        {
            dbConnection = new MySqlConnection(_connectionString);

            var SqlCommand = $"Proc_Check{typeCode}Exists";
            var param = new DynamicParameters();
            param.Add($"@{typeCode}", code);
            var result = dbConnection.QueryFirstOrDefault<bool>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);

            return result;
        }
        public string GetNewCode()
        {
            using (dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(NdlEntities).Name;
                var SqlCommand = $"Proc_GetNew{name}Code";
                var result = dbConnection.QueryFirstOrDefault<string>(SqlCommand, commandType: CommandType.StoredProcedure);

                return result;
            }

        }
        public IEnumerable<NdlEntities> getCusPaging(int m_PageIndex, int m_PageSize)
        {
            var connectionString = "" +
                "Host= 47.241.69.179;" +
                "Port= 3306;" +
                "Database = MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password=12345678";
            IDbConnection dbConnection = new MySqlConnection(_connectionString);
            var SqlCommand = "Proc_GetCustomerPaging";
            var param = new DynamicParameters();
            param.Add("@m_PageIndex", m_PageIndex);
            param.Add("@m_PageSize", m_PageSize);
            var result = dbConnection.Query<NdlEntities>(SqlCommand, param: param, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<NdlEntities> getPaging(int PageNumber, int PageSize, string SearchString)
        {
            using (dbConnection = new MySqlConnection(_connectionString))
            {
                var name = typeof(NdlEntities).Name;
                var SqlCommand = $"Proc_GetPaging{name}s";
                var param = new DynamicParameters();
                param.Add("@PageNumber", PageNumber);
                param.Add("@PageSize", PageSize);
                param.Add("@SearchString", SearchString);
                var result = dbConnection.Query<NdlEntities>(SqlCommand,param : param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}

