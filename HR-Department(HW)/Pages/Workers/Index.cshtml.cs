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
    public class IndexModel : PageModel
    {

        private readonly HR_Department_HW_.Data.ApplicationDbContext _context;

        public IndexModel(HR_Department_HW_.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Worker> Worker { get;set; }

        public string CurrentFilter { get; set; }
        public string NameSort { get; set; }
        public string CurrentSort { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder, string searchString)
        {
            CurrentFilter = searchString;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "WorkerName" : "";

            Worker = await _context.Workers
                .Include(w => w.Department)
                .Include(w => w.Position).ToListAsync();

            
            if (!String.IsNullOrEmpty(searchString))
            {
                Worker = Worker.Where(s => s.WorkerName.Contains(searchString) || s.WorkerSurname.Contains(searchString)).ToList();
            };

            
            switch (sortOrder)
            {
                case "WorkerName":
                    Worker = Worker.OrderBy(s => s.WorkerName).ToList();
                    break;
            }

            if (User.Identity.IsAuthenticated)
                return Page();
            else
                return RedirectToPage("/Access/403");
        }
    }
}
