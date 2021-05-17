using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.DL
{
    public interface IBaseDL <NdlEntities>
    {
        public IEnumerable<NdlEntities> getAll();
        public int Insert(NdlEntities entity);
        public NdlEntities getById(string entityId);
        public int Update(NdlEntities entity, string id);
        public int Delete(string id);
        public bool GetCodeExist(string code, string typeCode);
        public string GetNewCode();
        public IEnumerable<NdlEntities> getPaging(int PageNumber, int PageSize, string SearchString); 

    }
}
