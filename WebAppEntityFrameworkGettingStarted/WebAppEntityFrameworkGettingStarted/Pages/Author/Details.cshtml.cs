using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppEntityFrameworkGettingStarted.Data;

namespace WebAppEntityFrameworkGettingStarted.Pages.Author;

public class DetailsModel : PageModel
{
    private readonly BookStoreContext _context;

    public DetailsModel(BookStoreContext context)
    {
        _context = context;
    }

    public Model.Author Author { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Authors == null) return NotFound();

        var author = await _context.Authors.FirstOrDefaultAsync(m => m.AuthorId == id);
        if (author == null)
            return NotFound();
        Author = author;
        return Page();
    }
}