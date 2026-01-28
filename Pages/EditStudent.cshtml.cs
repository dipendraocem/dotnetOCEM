using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Data;
using RazorApp.Models;
public class EditStudentModel : PageModel
{
    private readonly AppDbContext _context;

    public EditStudentModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Student Student { get; set; }
    // Load student data when page loads (GET)
    public IActionResult OnGet(int id)
    {
             /* var student = _context.Students.Find(id);
                     _context.Students.Remove(student);
                     _context.SaveChanges();
                     return RedirectToPage("Students");
            */
            Student = _context.Students.Find(id);
            if (Student == null)
            {
                return RedirectToPage("Students"); // If student not found, redirect
            }
            return Page();
        
    }

    // Delete student (POST)
    public IActionResult OnPost()
    {
        if (Student == null || Student.Id == 0)
        {
            return RedirectToPage("Students");
        }

        var studentUpdate = _context.Students.Find(Student.Id);

        if (studentUpdate != null)
        {
            studentUpdate.Name = Student.Name;
            studentUpdate.Email = Student.Email;
            _context.SaveChanges();
        }
        return RedirectToPage("Students");
    }
}
