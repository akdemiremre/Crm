using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Core.DataAccess
{
    public interface IDataAccess<T>
    {
        List<T> List();
        IQueryable ListQueryable();

        List<T> List(Expression<Func<T, bool>> where);

        //IQueryable<T> List(Expression<Func<T, bool>> where);

        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        T Find(Expression<Func<T, bool>> where);

        int Save();
        
    }
}
