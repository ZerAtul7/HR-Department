using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HR_Department_HW_.Data;
using HR_Department_HW_.Models;

namespace HR_Department_HW_.Pages.Positions
{
    public class IndexModel : PageModel
    {
        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public IndexModel(HR_Department_HW_.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Position> Position { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Position = await _context.Positions.ToListAsync();
            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/403");
        }
    }
}
