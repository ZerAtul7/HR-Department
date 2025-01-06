using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HR_Department_HW_.Data;
using HR_Department_HW_.Models;

namespace HR_Department_HW_.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public IndexModel(HR_Department_HW_.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Department = await _context.Departments.ToListAsync();
            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/403");
        }
    }
}
