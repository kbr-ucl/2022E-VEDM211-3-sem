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
    public class IndexModel : PageModel
    {
        private readonly WebAppEntityFrameworkGettingStarted.Data.BookStoreContext _context;

        public IndexModel(WebAppEntityFrameworkGettingStarted.Data.BookStoreContext context)
        {
            _context = context;
        }

        public IList<Model.Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books.ToListAsync();
            }
        }
    }
}
