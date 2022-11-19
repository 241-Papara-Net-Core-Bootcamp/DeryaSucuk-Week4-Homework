using Microsoft.EntityFrameworkCore;
using PaparaThirdWeek.Data.Abstracts;
using PaparaThirdWeek.Data.Context;
using PaparaThirdWeek.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PaparaThirdWeek.Data.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public PaparaAppDbContext Context { get; }
        public Repository(PaparaAppDbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public IQueryable<T> Get()
        {
            return Context.Set<T>()
                .Where(x => !x.IsDeleted)
                .AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>()
                .Where(expression)
                .AsQueryable();
        }

        public void HardRemove(T entity)
        {
            T existData = Context.Set<T>().Find(entity.Id);
            if (existData != null)
            {
                Context.Set<T>().Remove(existData);
                Context.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            //T existData = Context.Set<T>().Find(entity.Id);
            //if (existData != null)
            //{
            //    existData.IsDeleted = true;
            //    Context.Entry(existData).State = EntityState.Modified;
            //    Context.SaveChanges();
            //}
            Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            T existData = Context.Set<T>().Find(entity.Id);
            if (existData is not null)
            {
                existData.IsDeleted = true;
                Context.Entry(existData).State = EntityState.Deleted;
                Context.SaveChanges();
            }
        }

        public IQueryable<T> GetById(int id)
        {
            return Context.Set<T>().Where(x => x.Id == id).AsQueryable();

        }

      
    }
}
