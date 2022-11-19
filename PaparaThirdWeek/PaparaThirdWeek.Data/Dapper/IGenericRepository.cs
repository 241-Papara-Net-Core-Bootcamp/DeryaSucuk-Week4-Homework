using PaparaThirdWeek.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Data.Dapper
{
    public interface IGenericRepository<T> where T : class
    {

        //Task<T> GetByIdAsync(int id);
        //Task<IReadOnlyList<T>> GetAllAsync();
        //Task<T> AddAsync(T entity);
        //Task<int> UpdateAsync(T entity);
        //Task<int> DeleteAsync(int id);

        //IQueryable<T> Get();
      //  IQueryable<T> GetAll();
        IQueryable<T> GetById(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);

    }
}
