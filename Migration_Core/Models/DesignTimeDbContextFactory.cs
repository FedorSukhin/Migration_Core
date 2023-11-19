using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration_Core.Models
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DbContextApp> 
    {
        public DbContextApp CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config["ConnectionString"];

            var options = new DbContextOptionsBuilder<DbContextApp>()
                .UseSqlServer(connectionString)
                .Options;

            return new DbContextApp(options);
        }
    }
}

