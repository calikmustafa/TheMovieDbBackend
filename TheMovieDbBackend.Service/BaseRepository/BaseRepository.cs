using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheMovieDbBackend.Core.Pagination;

namespace TheMovieDbBackend.Service.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly TheMovieDbContext _context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(TheMovieDbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return dbSet.FindAsync(id);
        }
        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<TEntity> AddAsyncWithReturn(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);

        }

        public IQueryable<TEntity> GetAll(List<Expression<Func<TEntity, bool>>> expressions, PagingParams pagingParams)
        {

            var predicate = PredicateBuilder.New<TEntity>();

            foreach (var item in expressions)
            {
                predicate.And(item);
            }


            if (pagingParams.PageNumber > 1)
            {
                pagingParams.Offset = pagingParams.PageSize * (pagingParams.PageNumber - 1);
            }
            else pagingParams.Offset = 0;

            return dbSet.Where(predicate).AsNoTracking().OrderBy(pagingParams.Orderby, pagingParams.OrderbyAsc).Skip(pagingParams.Offset).Take(pagingParams.PageSize);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {

            return dbSet.AsNoTracking().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {

            return dbSet.AsNoTracking();
        }



        public int GetAllTableCount(List<Expression<Func<TEntity, bool>>> expressions)
        {
            var predicate = PredicateBuilder.New<TEntity>();

            foreach (var item in expressions)
            {
                predicate.And(item);
            }

            return dbSet.AsNoTracking().Where(predicate).Count();
        }


        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }


        public void Update(TEntity newEntity, TEntity updatedEntity)
        {

            foreach (var prop in typeof(TEntity).GetProperties())
            {
                var toProp = typeof(TEntity).GetProperty(prop.Name);
                var toValue = toProp.GetValue(newEntity, null);
                if (!(toValue == null || toValue.ToString() == (Guid.Empty).ToString() || toValue.ToString() == DateTime.MinValue.ToString()))
                {
                    prop.SetValue(updatedEntity, toValue, null);

                }
            }

            dbSet.Update(updatedEntity);

        }

        public IQueryable<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {

            IQueryable<TEntity> queryable = _context.Set<TEntity>().AsNoTracking().Where(predicate);
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<TEntity, object>(includeProperty);
            }

            return queryable;
        }




        public void UpdateSingleProperty(TEntity entity, string propertyName, dynamic value)
        {
            entity.GetType().GetProperty(propertyName).SetValue(entity, value, null);
            _context.Entry(entity).Property(propertyName).IsModified = true;
            _context.Update(entity);

        }
    }
}
