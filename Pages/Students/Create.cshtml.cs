using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAssignment1.Data;
using RazorPagesAssignment1.Model;

namespace RazorPagesAssignment1.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesAssignment1.Data.RazorPagesAssignment1Context _context;

        public CreateModel(RazorPagesAssignment1.Data.RazorPagesAssignment1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Details Details { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Details.Add(Details);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
