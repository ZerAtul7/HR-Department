using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Department_HW_.Data;
using HR_Department_HW_.Models;

namespace HR_Department_HW_.Pages.Workers
{
    public class CreateModel : PageModel
    {
        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public CreateModel(HR_Department_HW_.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
        ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName");
            if (User.Identity.IsAuthenticated && User.Identity.Name == "admin123@gmail.com" || User.Identity.IsAuthenticated && User.Identity.Name == "hr123@gmail.com")
                return Page();
            else
                return RedirectToPage("/Access/403");
        }

        [BindProperty]
        public Worker Worker { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workers.Add(Worker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
