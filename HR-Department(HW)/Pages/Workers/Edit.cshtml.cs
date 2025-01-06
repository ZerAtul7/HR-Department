using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR_Department_HW_.Data;
using HR_Department_HW_.Models;

namespace HR_Department_HW_.Pages.Workers
{
    public class EditModel : PageModel
    {
        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public EditModel(HR_Department_HW_.Data.ApplicationDbContext context)
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
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
           ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName");
            if (User.Identity.IsAuthenticated && User.Identity.Name == "admin123@gmail.com")
                return Page();
            else
                return RedirectToPage("/Access/403");
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Worker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(Worker.WorkerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.WorkerId == id);
        }
    }
}
