using Microsoft.EntityFrameworkCore;
using WebAppEntityFrameworkGettingStarted.Model;

namespace WebAppEntityFrameworkGettingStarted.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
