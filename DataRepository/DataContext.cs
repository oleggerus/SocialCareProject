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

        }
        public DbSet<User> Users { get; set; }

    }
}
