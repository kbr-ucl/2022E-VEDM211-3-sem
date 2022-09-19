using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppEntityFrameworkGettingStarted.Data;

namespace WebAppEntityFrameworkGettingStarted.Pages.Author;

public class DeleteModel : PageModel
{
    private readonly BookStoreContext _context;

    public DeleteModel(BookStoreContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Author Author { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Authors == null) return NotFound();

        var author = await _context.Authors.FirstOrDefaultAsync(m => m.AuthorId == id);

        if (author == null)
            return NotFound();
        Author = author;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Authors == null) return NotFound();
        var author = await _context.Authors.FindAsync(id);

        if (author != null)
        {
            Author = author;
            _context.Authors.Remove(Author);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}