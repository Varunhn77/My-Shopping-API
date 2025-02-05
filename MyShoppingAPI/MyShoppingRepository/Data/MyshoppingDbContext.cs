using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShoppingEntity;

namespace MyShoppingRepository.Data
{
    public class MyshoppingDbContext : DbContext
    {
        public MyshoppingDbContext(DbContextOptions<MyshoppingDbContext>options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
