using System.ComponentModel.DataAnnotations;

namespace WebAppEntityFrameworkGettingStarted.Model;

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string WebUrl { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }

    public ICollection<Book> Books { get; set; }
}