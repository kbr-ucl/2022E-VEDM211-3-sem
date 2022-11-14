using Microsoft.EntityFrameworkCore;

namespace TransactionInjector.DatabaseModel
{
    public class BookStoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/breaking-changes
            optionsBuilder.UseSqlServer(@"Server=.;Database=EFCoreTransactionsDemo;Trusted_Connection=True; TrustServerCertificate=True; Encrypt=false; MultipleActiveResultSets=true");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
