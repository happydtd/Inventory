using Inventory.WCF.Interface;
using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Service
{
    public class BaseService: IBaseService
    {

        //public IEnumerable<T> Delete<T>(List<T> tList, int id) where T : BaseModel
        //{
        //    tList?.RemoveAt(id);
        //    return tList;
        //}

        //public IEnumerable<T> Delete<T>(List<T> tList, T t) where T : BaseModel
        //{
        //    tList?.Remove(t);
        //    return tList;
        //}

        public int Find<T>(List<T> tList, T t) where T : BaseModel
        {
            var index = tList?.IndexOf(t);
            if (index.HasValue)
                return index.Value;
            else
                return -1;
        }

        public IEnumerable<T> Insert<T>(List<T> tList, T t) where T : BaseModel
        {
            tList?.Add(t);
            return tList;
        }


        public IEnumerable<T> Query<T>(List<T> tList, Func<T, bool> funcWhere) where T : BaseModel
        {
            return tList.Where<T>(funcWhere);
        }


        public IEnumerable<T> Update<T>(List<T> tList, T t) where T : BaseModel
        {
            var item = tList?.Where(i => i.Id == t.Id).First();
            if (item != null)
            {
                item = t;
            }
            return tList;
        }

        public virtual void InitializeList()
        {
            
        }
    }
}
