using Demo_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo_Razor.Pages.Student
{
    public class AddModel : PageModel
    {
        private readonly Prn221_DB_SE1747Context _context = new Prn221_DB_SE1747Context();
        public List<Department>? departs { get; set; }
        public void OnGet()
        {
            departs = _context.Departments.ToList();
        }

        public async Task<IActionResult> OnPost(IFormCollection formCollection)
        {
            var maxStudentId = _context.Students.Max(x => x.Id);

            try
            {
                var student = new Models.Student
                {
                    Id = maxStudentId++,
                    Name = formCollection["Name"],
                    Gender = formCollection["Gender"] == "true" ? true : false,
                    Dob = formCollection["Dob"].ToString() == "" ? null : (System.DateTime?)System.DateTime.Parse(formCollection["Dob"]),
                    Gpa = double.Parse(formCollection["Gpa"]),
                    DepartId = formCollection["DepartId"]
                };

                await _context.Students.AddAsync(student);
                _context.SaveChanges();
            } catch (System.Exception)
            {
                throw;
            }
            
            return RedirectToPage("List");
        }
    }
}
