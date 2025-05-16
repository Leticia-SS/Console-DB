using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using consoleDB.Models;
using Microsoft.EntityFrameworkCore;

namespace consoleDB.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Product> Products { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
