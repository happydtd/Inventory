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
        static object lockObj = new object();

        public T Find<T>(List<T> tList, Guid id) where T : BaseModel
        {
            return tList?.Find(i=>i.Id == id);
        }

        public IEnumerable<T> Add<T>(List<T> tList, T t) where T : BaseModel
        {
            lock (lockObj)
            {
                tList?.Add(t);
            }
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
    }
}
