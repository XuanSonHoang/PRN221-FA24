using Demo_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo_Razor.Pages.Student
{
    public class UpdateModel : PageModel
    {
        private readonly Prn221_DB_SE1747Context _context = new Prn221_DB_SE1747Context();
        public Models.Student? Student { get; set; }

        public List<Models.Department>? departs { get; set; }
        public void OnGet(int studentId)
        {
            Student = GetStudentById(studentId);
            departs = _context.Departments.ToList();
        }

        public IActionResult OnPost(IFormCollection formCollection)
        {
            var student = GetStudentById(int.Parse(formCollection["Id"]));

            student.Name = formCollection["Name"];
            student.Gpa = double.Parse(formCollection["Gpa"]);
            student.Gender = formCollection["Gender"] == "true" ? true : false;
            student.Dob = formCollection["Dob"].ToString() == "" ? null : (System.DateTime?)System.DateTime.Parse(formCollection["Dob"]);
            student.DepartId = formCollection["DepartId"];

            try
            {
                _context.Students.Update(student);
                _context.SaveChanges();
            } catch(Exception ex)
            {
                throw;
            }

            return RedirectToPage("List");
        }

        private Models.Student GetStudentById(int studentId)
        {
            return _context.Students.Where(x => x.Id == studentId)?.FirstOrDefault();
        }
    }
}
