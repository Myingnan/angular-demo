using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using App.Tools.Extensions;
using App.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace App.Data.DataBase
{
    public class EFDbContext : DbContext, IDbContext
    {
        public IConfiguration Configuration { get; }

        public EFDbContext(DbContextOptions<EFDbContext> options, IConfiguration configuration) :base(options)
        {
            Configuration = configuration;
        }

        public DatabaseFacade GetDatabase() => Database;

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //将实现了IEntityTypeConfiguration<Entity>接口的模型配置类加入到modelBuilder中，进行注册
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);

            }

            base.OnModelCreating(modelBuilder);

         //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }

        public void BulkInsert<T>(IList<T> entities, string destinationTableName = null) where T : class
        {
            if (entities == null || !entities.Any()) return;
            if (string.IsNullOrEmpty(destinationTableName))
            {
                var mappingTableName = typeof(T).GetCustomAttribute<TableAttribute>()?.Name;
                destinationTableName = string.IsNullOrEmpty(mappingTableName) ? typeof(T).Name : mappingTableName;
            }
            SqlBulkInsert<T>(entities, destinationTableName);
        }


        private void SqlBulkInsert<T>(IList<T> entities, string destinationTableName = null) where T : class
        {
            using (var dt = entities.ToDataTable())
            {
                dt.TableName = destinationTableName;
                var connection= Configuration.GetConnectionString("MsSqlServer");
                using (var conn = Database.GetDbConnection() as SqlConnection ?? new SqlConnection(connection))
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            var bulk = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran)
                            {
                                BatchSize = entities.Count,
                                DestinationTableName = dt.TableName,
                            };
                            GenerateColumnMappings<T>(bulk.ColumnMappings);
                            bulk.WriteToServerAsync(dt);
                            tran.Commit();
                        }
                        catch (Exception)
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void GenerateColumnMappings<T>(SqlBulkCopyColumnMappingCollection mappings)
         where T : class
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.GetCustomAttributes<KeyAttribute>().Any())
                {
                    mappings.Add(new SqlBulkCopyColumnMapping(property.Name, typeof(T).Name + property.Name));
                }
                else
                {
                    mappings.Add(new SqlBulkCopyColumnMapping(property.Name, property.Name));
                }
            }
        }
    }
}
