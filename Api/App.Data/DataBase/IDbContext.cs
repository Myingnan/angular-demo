using App.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Data.DataBase
{
   public interface IDbContext
   {
        DbSet<T> GetDbSet<T>() where T : class;

        DatabaseFacade GetDatabase();

        int SaveChanges();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;

        void BulkInsert<T>(IList<T> entities, string destinationTableName = null) where T : class;
    }
}
