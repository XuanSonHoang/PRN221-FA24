using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo_Razor.Pages.Demo
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Please enter your email";
            ViewData["Message"] = Message;
        }

        public IActionResult OnPost()
        {
            if(string.IsNullOrEmpty(Email))
            {
                Message = "Please enter your email";
            }
            else
            {
                Message = $"Thank you for your email: {Email}";
            }

            ViewData["MessageSuccess"] = Message;

            return Page();
        }
    }
}
