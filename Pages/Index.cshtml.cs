using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorApp.Data;
using RazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; }

    public void OnGet()
        {
            Students = _context.Students.ToList();
        }
        
    }
}
