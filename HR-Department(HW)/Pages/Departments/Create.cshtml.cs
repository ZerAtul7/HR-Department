using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Department_HW_.Data;
using HR_Department_HW_.Models;

namespace HR_Department_HW_.Pages.Departments
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
            if (User.Identity.IsAuthenticated && User.Identity.Name == "admin123@gmail.com")
                return Page();
            else
                return RedirectToPage("/Access/403");
        }

        [BindProperty]
        public Department Department { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
