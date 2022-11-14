using System.Data;
using Microsoft.EntityFrameworkCore;
using TransactionExecuter.DatabaseModel;

namespace TransactionExecuter;

public class TransactionDemo
{
    public int SetupDatabase()
    {
        int created;
        using (var db = new BookStoreContext())
        {
            if (db.Books.Any()) return 0;

            Author author;
            if (!db.Authors.Any())
                author = new Author
                {
                    Name = "Robert C. Martin",
                    WebUrl = "http://cleancoder.com/products"
                };
            else
                author = db.Authors.First();

            var book = new Book
            {
                Author = author, Title = "Clean Architecture", Description = "", PublishedOn = new DateTime(2018, 1, 1)
            };
            db.Books.Add(book);
            created = db.SaveChanges();
        }

        return created;
    }

    public int TearDownDatabase()
    {
        int deleted;
        using (var db = new BookStoreContext())
        {
            var books = db.Books.ToList();
            db.RemoveRange(books);

            var authors = db.Authors.ToList();
            db.RemoveRange(authors);

            deleted = db.SaveChanges();
        }

        return deleted;
    }

    public void ShowBooks()
    {
        using (var db = new BookStoreContext())
        {
            var author = db.Authors.Include(a => a.Books).AsNoTracking()
                .FirstOrDefault(a => a.Name == "Robert C. Martin");
            if (author == null)
            {
                Console.WriteLine("No books");
                return;
            }

            Console.WriteLine($"{author.Name} books:");
            foreach (var book in author.Books) Console.WriteLine($"{book.PublishedOn}, {book.Title}");
        }
    }

    public void Phantoms()
    {
        using (var db = new BookStoreContext())
        {
            var author = db.Authors.Include(a => a.Books).FirstOrDefault(a => a.Name == "Robert C. Martin");
            Console.WriteLine("Do changes. Then check in SQL Management Studio and press any key when done");
            Console.ReadKey();
            foreach (var book in author.Books) book.PublishedOn += new TimeSpan(30, 20, 20, 20);

            db.SaveChanges();
        }
    }


    public void PhantomsFixed()
    {
        using (var db = new BookStoreContext())
        {
            using (var transaction = db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var author = db.Authors.Include(a => a.Books).FirstOrDefault(a => a.Name == "Robert C. Martin");
                    Console.WriteLine("Do changes in SQL Management Studio and press any key when done");
                    Console.ReadKey();
                    foreach (var book in author.Books) book.PublishedOn += new TimeSpan(30, 20, 20, 20);

                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    transaction.Rollback();
                }
            }
        }
    }
}