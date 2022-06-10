using System.Linq.Expressions;
using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Interface;
using Microsoft.EntityFrameworkCore;

namespace Beetsoft_Management_System.Repository
{
    public abstract class RepositoryBase<T> :   IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
    }
}