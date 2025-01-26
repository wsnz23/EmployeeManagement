﻿using EmployeeManagement.Data;
using EmployeeManagement.Models.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeManagement.Models.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDBContext _dbContext;
        private readonly DbSet<T> _db;

        public GenericRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _db = _dbContext.Set<T>();
        }

        public async Task Delete(int id)
        {
           var entity = await _db.FindAsync(id);
            _db.Remove(entity);

        }

        public void DeleteRange(IEnumerable<T> entities)
        {
         _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
           IQueryable<T> query = _db;
            if (include != null) { 
                query= include(query);
             
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if(include != null)
            {
                query=include(query);
            }
            if(orderBy != null)
            {
                query=orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
          await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);

        }

        public void Update(T entity)
        {
            _db.Add(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }

}
