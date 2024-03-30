using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WPFArchitecturePractice.DAL
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        }
    }

    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }
        [Required]
        public BookCategoryEntity category { get; set; }
    }
}