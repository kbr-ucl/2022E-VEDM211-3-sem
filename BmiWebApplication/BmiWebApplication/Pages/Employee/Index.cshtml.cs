using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BmiWebApplication.Pages.Employee;

public class IndexModel : PageModel
{
    [BindProperty] public Employee Employee { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
            return;

        RedirectToPage("/Employee/Index");
    }
}

public class Employee
{
    public int ID { get; set; }

    [Required]
    [MinLength(2,  ErrorMessage = "Name lenght should be 2 to 50.")]
    [StringLength(50, ErrorMessage = "Name lenght should be 1 to 50.")]
    [Display(Name = "Employee Name")]
    public string Name { get; set; }


    [Required]
    [StringLength(255, ErrorMessage = "Address lenght should be 1 to 255.")]
    [Display(Name = "Address")]
    public string Address { get; set; }
}

