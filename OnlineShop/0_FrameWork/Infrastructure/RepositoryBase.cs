using _0_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Infrastructure
{
    public class RepositoryBase<TKey, T> : Irepository<TKey, T> where T : class
    {
        private readonly DbContext _cotext;

        public RepositoryBase(DbContext cotext)
        {
            _cotext=cotext;
        }

        public void Create(T entity)
        {
            _cotext.Add(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _cotext.Set<T>().Any(expression);
        }

        public T Get(TKey id)
        {
            return _cotext.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _cotext.Set<T>().ToList();
        }

        public void SaveChanges(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
