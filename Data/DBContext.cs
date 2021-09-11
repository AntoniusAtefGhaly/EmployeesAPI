using System;
using EmployeesAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeesAPI.Data
{
     public partial class DBContext : DbContext
    {

        public DBContext()
        {
        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EmployeesDB;Integrated Security=True");
            }
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTaxs> EmployeeTaxs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
           
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        

    }
    public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EmployeesDB;Integrated Security=True");

            return new DBContext(optionsBuilder.Options);
        }
    }
}