using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entities;
using DataRepository.Entities.Orders;
using DataRepository.Entities.People;

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
            modelBuilder.Entity<Provider>()
                .HasRequired(c => c.User)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReturnRequest>()
                .HasRequired(c => c.Offer)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasRequired(c => c.Role)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasRequired(c => c.CreatedBy)
                .WithMany()
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Worker>()
                .HasRequired(c => c.Administration)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasRequired(c => c.Administration)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkerPersonAssignment>()
                .HasRequired(c=> c.Worker)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<WorkerPersonAssignment>()
                .HasRequired(c => c.Customer)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PersonRequest>()
                .HasRequired(c => c.Customer)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PersonRequest>()
                .HasRequired(c => c.CreatedBy)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administration> Administrations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PersonRequest> PersonRequests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSchedule> ProductSchedules { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerPersonAssignment> WorkerPersonAssignments { get; set; }
        public DbSet<CareRequest> CareRequests { get; set; }

    }
}
