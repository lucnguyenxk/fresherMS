using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.SV
{
    public interface IBaseSV<NdlEntities> 
    {
        IEnumerable<NdlEntities> getAll();
        NdlEntities getById(Guid id);
        int Insert(NdlEntities entity);
        int Update(NdlEntities entity, Guid id);
        int Delete(Guid id);
        public string GetNewCode();
        IEnumerable<NdlEntities> getPaging(int PageNumber, int PageSize, string SearchString);
    }
}
