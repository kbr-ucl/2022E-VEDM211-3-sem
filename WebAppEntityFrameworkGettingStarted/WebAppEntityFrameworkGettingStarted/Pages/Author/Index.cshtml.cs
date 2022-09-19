using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppEntityFrameworkGettingStarted.Data;

namespace WebAppEntityFrameworkGettingStarted.Pages.Author;

public class IndexModel : PageModel
{
    private readonly BookStoreContext _context;

    public IndexModel(BookStoreContext context)
    {
        _context = context;
    }

    public IList<Model.Author> Author { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Authors != null) Author = await _context.Authors.ToListAsync();
    }
}