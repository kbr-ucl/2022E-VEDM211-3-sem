using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BmiWebApplication.Pages.Bmi
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public BmiViewModel BmiModel { get; set; } = new();


        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (BmiModel.Height.HasValue && BmiModel.Weigth.HasValue)
                BmiModel.Bmi = BmiModel.Weigth.Value / (BmiModel.Height.Value * BmiModel.Height.Value);

            //if (BmiModel.Height != default && BmiModel.Weigth != default)
            //    BmiModel.Bmi = BmiModel.Weigth / (BmiModel.Height * BmiModel.Height);

        }
    }
}
