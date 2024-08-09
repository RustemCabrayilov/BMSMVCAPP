using Azure;
using BMS.DAL.Data;
using BMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BMS.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly BMSDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(BMSDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        /*    await _dbContext.SaveChangesAsync();*/
            return entity;
        }

        public T Delete(int id)
        {
            var entity =  _dbSet.Find(id);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<T> Get(int id,params string[] includes)
        {
            var query =  _dbSet.Where(x=>x.Id==id).AsQueryable();
           
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<IQueryable<T>> GetAll(params string[] includes)
        {
			var query = _dbSet.AsQueryable();
			if (includes is not null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}
			return  query;

        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
		public async Task SaveAsync()
		{
			 await _dbContext.SaveChangesAsync();
		}
	}
}
