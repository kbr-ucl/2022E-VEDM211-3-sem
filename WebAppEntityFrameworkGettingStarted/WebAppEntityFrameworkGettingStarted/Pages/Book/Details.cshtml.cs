using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppEntityFrameworkGettingStarted.Data;
using WebAppEntityFrameworkGettingStarted.Model;

namespace WebAppEntityFrameworkGettingStarted.Pages.Book
{
    public class DetailsModel : PageModel
    {
        private readonly WebAppEntityFrameworkGettingStarted.Data.BookStoreContext _context;

        public DetailsModel(WebAppEntityFrameworkGettingStarted.Data.BookStoreContext context)
        {
            _context = context;
        }

      public Model.Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
