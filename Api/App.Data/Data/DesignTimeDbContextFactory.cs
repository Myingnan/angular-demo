using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using App.Data.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Data.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EFDbContext>
    {
        public EFDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<EFDbContext>();
            var connectionString = configuration.GetConnectionString("MsSqlServer");
            builder.UseSqlServer(connectionString);
            return new EFDbContext(builder.Options, configuration);
        }
    }
}
