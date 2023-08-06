using Microsoft.EntityFrameworkCore;
using flash_card.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace flash_card.Data
{
    public class FlashCardContext : IdentityDbContext<AppUser>
    {
        public FlashCardContext (DbContextOptions<FlashCardContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder){
            base.OnModelCreating (modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()){
                string? tableName = entityType.GetTableName();
                if(tableName.StartsWith("AspNet")){
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        public DbSet<Word> Word { get; set; }

    }
}
