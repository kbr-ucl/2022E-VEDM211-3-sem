using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppEntityFrameworkGettingStarted.Data;

namespace WebAppEntityFrameworkGettingStarted.Pages.Author;

public class EditModel : PageModel
{
    private readonly BookStoreContext _context;

    public EditModel(BookStoreContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Author Author { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Authors == null) return NotFound();

        var author = await _context.Authors.FirstOrDefaultAsync(m => m.AuthorId == id);
        if (author == null) return NotFound();
        Author = author;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        using (var transaction = _context.Database.BeginTransaction(IsolationLevel.Serializable))
        {

            _context.Attach(Author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(Author.AuthorId))
                    return NotFound();
                throw;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
            }
        }

        return RedirectToPage("./Index");
    }

    private bool AuthorExists(int id)
    {
        return _context.Authors.Any(e => e.AuthorId == id);
    }
}