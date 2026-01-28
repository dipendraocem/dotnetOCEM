using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Data;
using RazorApp.Models;
public class DeleteStudentModel : PageModel
{
    private readonly AppDbContext _context;
    public DeleteStudentModel(AppDbContext context)
    {
        _context = context;
    }
    [BindProperty]
    public Student Student { get; set; }
    public IActionResult OnGet(int id)
    {
         var student = _context.Students.Find(id);
                     _context.Students.Remove(student);
                     _context.SaveChanges();
                     return RedirectToPage("Students"); 
        
}

    // Delete student (POST)
    public IActionResult OnPost()
    {
        if (Student == null || Student.Id == 0)
        {
            return RedirectToPage("Students");
        }

        var studentToDelete = _context.Students.Find(Student.Id);

        if (studentToDelete != null)
        {
            _context.Students.Remove(studentToDelete);
            _context.SaveChanges();
        }
        return RedirectToPage("Students");
    }
}
