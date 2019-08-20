using Microsoft.EntityFrameworkCore;
using App.Tools.Extensions;
using App.Core;
using App.Data.DataBase;
using App.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace App.Repositories.Repository
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        private readonly IDbContext _context;

        private DbSet<T> _entities=> _context.GetDbSet<T>();

        public Repository(IDbContext context)
        {
            _context = context;
        }

        #region Insert

        public virtual int Add(T entity)
        {
            _entities.Add(entity);
            return _context.SaveChanges();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual int AddRange(ICollection<T> entities)
        {
            _entities.AddRange(entities);
            return _context.SaveChanges();
        }

        public virtual async Task<int> AddRangeAsync(ICollection<T> entities)
        {
            await _entities.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public virtual void BulkInsert(IList<T> entities, string destinationTableName = null)
        {
            _context.BulkInsert<T>(entities, destinationTableName);
        }

        #endregion

        #region Update

        public virtual int Edit(T entity)
        {
            _entities.Update(entity);
            return _context.SaveChanges();
        }

        public virtual int EditRange(ICollection<T> entities)
        {
            _entities.UpdateRange(entities);
            return _context.SaveChanges();
        }
        /// <summary>
        /// update query datas by columns.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="updateExp"></param>
        /// <returns></returns>
        public virtual int BatchUpdate(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateExp)
        {
            return _entities.Where(where).Update(updateExp);
        }

        public virtual async Task<int> BatchUpdateAsync(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateExp)
        {
            return await _entities.Where(where).UpdateAsync(updateExp); ;
        }

        public virtual int Update(T model, params string[] updateColumns)
        {
            if (updateColumns != null && updateColumns.Length > 0)
            {
                if (_context.Entry(model).State == EntityState.Added ||
                    _context.Entry(model).State == EntityState.Detached) _entities.Attach(model);
                foreach (var propertyName in updateColumns)
                {
                    _context.Entry(model).Property(propertyName).IsModified = true;
                }
            }
            else
            {
                _context.Entry(model).State = EntityState.Modified;
            }
            return _context.SaveChanges();
        }

        #endregion

        #region Delete

        public virtual int Delete(Expression<Func<T, bool>> @where)
        {
            return _entities.Where(@where).Delete();
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> @where)
        {
            return await _entities.Where(@where).DeleteAsync();
        }


        #endregion

        #region Query

        public virtual int Count(Expression<Func<T, bool>> @where = null)
        {
            return _entities.Where(where).Count();
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> @where = null)
        {
            return await _entities.Where(where).CountAsync();
        }


        public virtual bool Exist(Expression<Func<T, bool>> @where = null)
        {
            return @where == null ? _entities.Any() : _entities.Any(@where);
        }

        public virtual async Task<bool> ExistAsync(Expression<Func<T, bool>> @where = null)
        {
            return await (@where == null ? _entities.AnyAsync() : _entities.AnyAsync(@where));
        }

        /// <summary>
        /// 根据主键获取实体。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T GetSingle(TKey key)
        {
            return _entities.Find(key);
        }

        public T GetSingle(TKey key, Func<IQueryable<T>, IQueryable<T>> includeFunc)
        {
            if (includeFunc == null) return GetSingle(key);
            return includeFunc(_entities.Where(m => m.Id.Equals(key))).AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// 根据主键获取实体。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual async Task<T> GetSingleAsync(TKey key)
        {
            return await _context.FindAsync<T>(key);
        }

        /// <summary>
        /// 获取单个实体。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        public virtual T GetSingleOrDefault(Expression<Func<T, bool>> @where = null)
        {
            return where == null ? _entities.SingleOrDefault() : _entities.SingleOrDefault(where);
        }

        /// <summary>
        /// 获取单个实体。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        public virtual async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> @where = null)
        {
            return await (where == null ? _entities.SingleOrDefaultAsync() : _entities.SingleOrDefaultAsync(where));
        }

        /// <summary>
        /// 获取实体列表。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> @where = null)
        {
            return (@where != null ? _entities.Where(@where).AsNoTracking() : _entities.AsNoTracking());
        }

        /// <summary>
        /// 获取实体列表。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        public virtual async Task<List<T>> GetAsync(Expression<Func<T, bool>> @where = null)
        {
            return await _entities.Where(where).ToListAsync();
        }

        /// <summary>
        /// 分页获取实体列表。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        public virtual IEnumerable<T> GetByPagination(Expression<Func<T, bool>> @where, int pageSize, int pageIndex, bool asc = true, params Func<T, object>[] @orderby)
        {
            var filter = Get(where).AsEnumerable();
            if (orderby != null)
            {
                foreach (var func in orderby)
                {
                    filter = asc ? filter.OrderBy(func) : filter.OrderByDescending(func);
                }
            }
            return filter.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        public List<T> GetBySql(string sql, params object[] parameters)
        {
            return _entities.FromSql(sql, parameters).ToList();
        }

        #endregion


        public int ExecuteSql(string sql, params object[] parameters)
        {
            return _context.GetDatabase().ExecuteSqlCommand(sql, CancellationToken.None, parameters);
        }
 

        public virtual IQueryable<T> QueryTable()
        {
           return _entities; 
        }
    }
}
