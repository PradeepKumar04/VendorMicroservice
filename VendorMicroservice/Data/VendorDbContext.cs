using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservice.Models;

namespace VendorMicroservice.Data
{
    public class VendorDbContext:DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorStock> VendorStocks { get; set; }

        public VendorDbContext(DbContextOptions<VendorDbContext> options):base(options)
        {

        }
    }
}
