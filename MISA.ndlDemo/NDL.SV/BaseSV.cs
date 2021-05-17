using NDL.Common.Attributes;
using NDL.DL;
using NDL.SV.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDL.SV
{
    public class BaseSV<NdlEntities> : IBaseSV<NdlEntities>
    {
        public IBaseDL<NdlEntities> _iBaseDL;
        public BaseSV(IBaseDL<NdlEntities> baseDL)
        {
            _iBaseDL = baseDL;
        }
        public IEnumerable<NdlEntities> getAll()
        {
            var result = _iBaseDL.getAll();
            return result;
        }
        public NdlEntities getById(Guid id)
        {
            var result = _iBaseDL.getById(id.ToString());
            return result;
        }
        public int Insert(NdlEntities entity)
        {
            Validate(entity);
            var result = _iBaseDL.Insert(entity);
            return result;
        }
        public int Update(NdlEntities entity, Guid id)
        {
            //Validate(entity);
            var result = _iBaseDL.Update(entity, id.ToString());
            return result;
        }
        public int Delete(Guid id)
        {
            var result = _iBaseDL.Delete(id.ToString());
            return result;

        }
        public virtual string GetNewCode()
        {
            var result = _iBaseDL.GetNewCode();
            var lenght = result.Length;
            string res = "";
            int i = 3;
            while(result[i] == '0'&& i <lenght)
            {
                res = res + '0';
                i++;
            }
            int rest = lenght - i;
            string restConvert = result.Substring(lenght - rest, rest);
            int Convert = int.Parse(restConvert);
            Convert += 1;
            res = res + Convert.ToString();

            return res;
        }
        protected virtual void Validate( NdlEntities entity){
            var properties = typeof(NdlEntities).GetProperties();
            foreach (var property in properties)
            {
                var ndlrequired = property.GetCustomAttributes(typeof(NdlRequired), true);
                var ndlDuplicate = property.GetCustomAttributes(typeof(NdlDuplicate), true);
                if (ndlrequired.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);
                    var propertyType = property.PropertyType;
                    if (propertyType == typeof(string) && string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var msgEr = (ndlrequired[0] as NdlRequired).MsgEr;
                        throw new NdlException<NdlEntities>(msgEr);
                    }
                }
                if(ndlDuplicate.Length > 0)
                {
                    var propertyValue = property.GetValue(entity).ToString();
                    var NameOfProperty = property.Name;
                    var checkcode = _iBaseDL.GetCodeExist(propertyValue, NameOfProperty);
                    if( checkcode == true)
                    {
                        var msgEr = (ndlDuplicate[0] as NdlDuplicate).MsgEr + propertyValue;
                        throw new NdlException<NdlEntities>(msgEr);
                    }

                }

            }
        }

        public IEnumerable<NdlEntities> getPaging(int PageNumber, int PageSize, string SearchString)
        {
            if (SearchString == null)
            {
                SearchString = "";
            }
            var result = _iBaseDL.getPaging(PageNumber, PageSize, SearchString);
            return result;
        }
    }
}
