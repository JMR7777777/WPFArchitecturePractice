using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFArchitecturePractice.DAL
{
    public class WPFArchitecturePraticeContext:DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<BookCategory> BookCategories => Set<BookCategory>();

    }
}
