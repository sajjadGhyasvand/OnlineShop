using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Domain
{
    public interface Irepository<TKey , T> where T : class
    {
        T Get(TKey id);
        List<T> GetAll();
        void Create(T entity);
        void SaveChanges(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
