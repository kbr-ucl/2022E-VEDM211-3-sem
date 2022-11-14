// See https://aka.ms/new-console-template for more information

using System.Text;
using TransactionInjector.DatabaseModel;

Console.WriteLine("Injecting a book");
using (var db = new BookStoreContext())
{
    if (!db.Authors.Any()) return;
    var author = db.Authors.First();

    var book = new Book
    {
        Author = author, Title = "Clean Architecture", Description = "", PublishedOn = new DateTime(2010, 1, 1)
    };
    db.Books.Add(book);
    try
    {
        db.SaveChanges();
    }
    catch (Exception e)
    {
        var sb = new StringBuilder(e.Message);
        var inner = e.InnerException;
        while (inner != null)
        {
            sb.Append(inner.Message);
            inner = inner.InnerException;
        }
        Console.WriteLine(sb);
    }

    Console.WriteLine("Injecting done");
}