using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class GraduationProjectContext:IdentityDbContext<User,Role,string>
    {
        public GraduationProjectContext(DbContextOptions<GraduationProjectContext> options):base(options)
        {

        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<BulkBorrowing> BulkBorrowings { get; set; }
        public DbSet<Collecting> Collectings { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<DebitType> DebitTypes { get; set; }
        public DbSet<DistributionType> DistributionTypes { get; set; }
        public DbSet<EmailSend> EmailSends { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
