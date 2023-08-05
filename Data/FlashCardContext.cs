using Microsoft.EntityFrameworkCore;
using flash_card.Models;

namespace flash_card.Data
{
    public class FlashCardContext : DbContext
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
        }

        public DbSet<Word> Word { get; set; }

    }
}
