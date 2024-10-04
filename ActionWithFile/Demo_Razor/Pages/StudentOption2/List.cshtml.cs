using Demo_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo_Razor.Pages.StudentOption2
{
    public class ListModel : PageModel
    {
        private readonly Prn221_DB_SE1747Context _context = new Prn221_DB_SE1747Context();

        public List<Models.Student> students;
        public void OnGet()
        {
            students = GetListStudent();
        }

        public IActionResult OnPost(IFormCollection iFormCollection)
        {
            var takeFromFormCollection = iFormCollection["searchName"].ToString();

            var stringSearch = Request.Form["searchName"].ToString();

            if (string.IsNullOrWhiteSpace(stringSearch))
            {
                students = _context.Students.Where(x => x.Name.Contains(stringSearch)).Include(x => x.Depart).ToList();
                return Page();
            }

            if (string.IsNullOrEmpty(stringSearch))
            {
                students = new List<Models.Student>();
            }
            else
            {
                students = _context.Students.Where(x => x.Name.Contains(stringSearch)).Include(x => x.Depart).ToList();
            }

            return Page();
        }

        private List<Models.Student> GetListStudent()
        {
            return _context.Students.Include(x => x.Depart).ToList();
        }
    }
}
