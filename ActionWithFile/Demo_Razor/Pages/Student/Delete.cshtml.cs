using Demo_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo_Razor.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private readonly Prn221_DB_SE1747Context _context = new Prn221_DB_SE1747Context();

        public IActionResult OnGet(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToPage("List");
        }

        private Models.Student GetStudentById(int studentId)
        {
            return _context.Students.FirstOrDefault(x => x.Id == studentId);
        }
    }
}
