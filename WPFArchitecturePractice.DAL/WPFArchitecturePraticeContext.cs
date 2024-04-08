using Microsoft.EntityFrameworkCore;
using WPFArchitecturePractice.Model.Rent;

namespace WPFArchitecturePractice.DAL
{
    public class WPFArchitecturePraticeContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置实体之间的关系等
            //modelBuilder.Entity<Book>()
            //            .HasOne(b => b.Category)
            //            .WithMany(c => c.Books)
            //            .HasForeignKey(b => b.CategoryId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..\\WPFArchitecturePractice.DAL\\WPFArchitecturePratice.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
