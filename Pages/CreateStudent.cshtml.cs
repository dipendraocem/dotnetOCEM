using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Models;
using RazorApp.Data;
public class CreateStudentModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateStudentModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Student Student { get; set; }

    // Handle form submission (POST)
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Students.Add(Student);
        _context.SaveChanges();

        return RedirectToPage("Students");
    }
}