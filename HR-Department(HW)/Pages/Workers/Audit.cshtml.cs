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
    public class AuditModel : PageModel
    {
        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public AuditModel(HR_Department_HW_.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Worker> Worker { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Worker = await _context.Workers
                .Include(w => w.Department)
                .Include(w => w.Position).ToListAsync();


            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/403");
        }
    }
}
