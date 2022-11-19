using Microsoft.Data.SqlClient;
using PaparaThirdWeek.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using PaparaThirdWeek.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;

//using System.Configuration;

namespace PaparaThirdWeek.Data.Dapper
{
    public class CompanyRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly IConfiguration configuration;
        public CompanyRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Add(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "Derya";
            entity.LastUpdateAt = DateTime.Now;
            entity.LastUpdateBy = "Hasan";
            entity.IsDeleted = true;
            var sql = "Insert into Companies(Name,Adress,Email,City) VALUES (@Name,@Adress,@Email,@City)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                connection.ExecuteAsync(sql, entity);
                
            }
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Companies WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                connection.ExecuteAsync(sql, new { Id = id });

            }
        }

        //public IQueryable<T> Get()
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<T> GetAll()
        //{
        //    var sql = "SELECT * FROM Companies";
        //    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = connection.QueryAsync<Company>(sql);
        //        return result.
        //    }
        //}

        public IQueryable<T> GetById(int id)
        {
            var sql = "SELECT * FROM Companies WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.QuerySingleOrDefaultAsync<Company>(sql, new { Id = id });

                return (IQueryable<T>)result;
            }
        }

        public void Update(T entity)
        {
            var sql = "UPDATE Companies SET Name = @Name, Adress = @Adress, City = @City, Email = @Email  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                connection.ExecuteAsync(sql, entity);
                
            }
        }
        //public async Task<int> AddAsync(T entity)
        //{
        //    entity.CreatedDate = DateTime.Now;
        //    entity.CreatedBy= "Derya";
        //    entity.LastUpdateAt = DateTime.Now;
        //    entity.LastUpdateBy = "Hasan";
        //    entity.IsDeleted = true;
        //    var sql = "Insert into Companies(Name,Adress,Email,City) VALUES (@Name,@Adress,@Email,@City)";
        //    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(sql, entity);
        //        return result;
        //    }
        //}

        //public async Task<int> DeleteAsync(int id)
        //{
        //    var sql = "DELETE FROM Companies WHERE Id = @Id";
        //    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(sql, new { Id = id });
        //        return result;
        //    }
        //}


        // public async Task<IReadOnlyList<Company>> GetAllAsync()
        //  {
        //      var sql = "SELECT * FROM Companies";
        //      using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //      {
        //          connection.Open();
        //          var result = await connection.QueryAsync<Company>(sql);
        //          return result.ToList();
        //      }
        //  }

        //public async Task<Company> GetByIdAsync(int id)
        //{
        //    var sql = "SELECT * FROM Companies WHERE Id = @Id";
        //    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync<Company>(sql, new { Id = id });

        //        return result;
        //    }
        //}

        //public async Task<int> UpdateAsync(T entity)
        //{
        //    var sql = "UPDATE Companies SET Name = @Name, Adress = @Adress, City = @City, Email = @Email  WHERE Id = @Id";
        //    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(sql, entity);
        //        return result;
        //    }
        //}

        //Task<IReadOnlyList<T>> IGenericRepository<T>.GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<T> IGenericRepository<T>.GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
