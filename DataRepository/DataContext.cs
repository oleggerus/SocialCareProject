using DataRepository.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class DataContext : DbContext
    {
        public DataContext() : base("StringDBContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>()
            //    .HasRequired(c => c.Administration)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Worker>()
                .HasRequired(c => c.Administration)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasRequired(c => c.Administration)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administration> Administrations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSchedule> ProductSchedules { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerPersonAssignment> WorkerPersonAssignments { get; set; }
        
    }
}
