using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAssignment1.Data;
using RazorPagesAssignment1.Model;

namespace RazorPagesAssignment1.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesAssignment1.Data.RazorPagesAssignment1Context _context;

        public DetailsModel(RazorPagesAssignment1.Data.RazorPagesAssignment1Context context)
        {
            _context = context;
        }

        public Details Details { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Details = await _context.Details.FirstOrDefaultAsync(m => m.ID == id);

            if (Details == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
