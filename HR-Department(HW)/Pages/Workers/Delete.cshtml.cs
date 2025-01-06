using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HR_Department_HW_.Data;
using HR_Department_HW_.Models;

namespace HR_Department_HW_.Pages.Workers
{
    public class DeleteModel : PageModel
    {
        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public DeleteModel(HR_Department_HW_.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _context.Workers
                .Include(w => w.Department)
                .Include(w => w.Position).FirstOrDefaultAsync(m => m.WorkerId == id);

            if (Worker == null)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated && User.Identity.Name == "admin123@gmail.com")
                return Page();
            else
                return RedirectToPage("/Access/403");
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _context.Workers.FindAsync(id);

            if (Worker != null)
            {
                _context.Workers.Remove(Worker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
