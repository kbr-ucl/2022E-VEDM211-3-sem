using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppEntityFrameworkGettingStarted.Data;

namespace WebAppEntityFrameworkGettingStarted.Pages.Book;

public class CreateModel : PageModel
{
    private readonly BookStoreContext _context;

    public CreateModel(BookStoreContext context)
    {
        _context = context;
    }

    [BindProperty] public Model.Book Book { get; set; }
    public List<SelectListItem> AuthorsList { get; set; }

    public IActionResult OnGet()
    {
        AuthorsList = _context.Authors.Select(a => 
            new SelectListItem 
            {
                Value = a.AuthorId.ToString(),
                Text =  a.Name
            }).ToList();
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Books.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}