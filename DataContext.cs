using Databasen1.Models;
using Databasen1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Databasen1.Context
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomas\Documents\SQL2\Databasen1\Databasen1\Context\SQL_db.mdf;Integrated Security=True;Connect Timeout=30";

        public DbSet<AdressEntities> Adress { get; set; }
        public DbSet<PropertiesEntities> Property { get; set; }
        public DbSet<RentalAgreementEntities> RentalAgreement { get; set; }
        public DbSet<TenantsEntities> Tenants { get; set; }

        public DbSet<Issue> Issue { get; set; }

        public DbSet<Comment> Comment { get; set; }



        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
