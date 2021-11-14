using Inventory.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WCF.Interface
{
    public interface IBaseService
    {
        int Find<T>(List<T> tList, T t) where T : BaseModel;

        IEnumerable<T> Query<T>(List<T> tList, Func<T, bool> funcWhere) where T : BaseModel;

        IEnumerable<T> Insert<T>(List<T> tList, T t) where T : BaseModel;

        IEnumerable<T> Update<T>(List<T> tList, T t) where T : BaseModel;

        //IEnumerable<T> Delete<T>(List<T> tList, int id) where T : BaseModel;

        //IEnumerable<T> Delete<T>(List<T> tList, T t) where T : BaseModel;

        void InitializeList();
    }
}
