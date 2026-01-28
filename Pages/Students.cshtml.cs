using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Data;
using RazorApp.Models;
namespace RazorApp.Pages;

public class StudentsModel : PageModel
{
     private readonly AppDbContext _context;

        public StudentsModel(AppDbContext context)
        {
            _context = context;
        }
    public IList<Student> Students { get; set; }

    public void OnGet()
        {
            Students = _context.Students.ToList();
        }
        
    }