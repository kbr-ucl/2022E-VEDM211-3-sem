using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IoCdemo1.Pages.Beregner
{
    public class IndexModel : PageModel
    {
        private readonly IBeregner _beregner;

        [BindProperty]
        public int Result { get; set; }

        public IndexModel(IBeregner beregner)
        {
            _beregner = beregner;
        }
        public void OnGet()
        {
            Result = _beregner.Add(10, 20);
        }
    }
}
