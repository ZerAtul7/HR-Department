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
    public class DetailsModel : PageModel
    {
        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public DetailsModel(HR_Department_HW_.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentId == id);

            if (Department == null)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/403");
        }
    }
}
