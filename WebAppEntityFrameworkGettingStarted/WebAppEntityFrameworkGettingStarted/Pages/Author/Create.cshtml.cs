using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppEntityFrameworkGettingStarted.Data;

namespace WebAppEntityFrameworkGettingStarted.Pages.Author;

public class CreateModel : PageModel
{
    private readonly BookStoreContext _context;

    public CreateModel(BookStoreContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Author Author { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Authors.Add(Author);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}