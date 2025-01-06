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
    public class DetailsModel : PageModel
    {
        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public DetailsModel(HR_Department_HW_.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
