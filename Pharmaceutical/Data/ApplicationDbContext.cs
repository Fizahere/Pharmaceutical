using Microsoft.EntityFrameworkCore;
using Pharmaceutical.Models;

namespace Pharmaceutical.Data;

public class ApplicationDbContext : DbContext
{
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Blending> Blendings { get; set; }
        public DbSet<Capsule> Capsules { get; set; }
        public DbSet<LiquidFilling> LiquidFillings { get; set; }
        public DbSet<ProcessEquipment> ProcessEquipments { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Tablet> Tablets { get; set; }
        public DbSet<UsedEquipment> UsedEquipments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCareer> UserCareers { get; set; }  
}
