using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesAssignment1.Data;
using RazorPagesAssignment1.Model;

namespace RazorPagesAssignment1.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesAssignment1.Data.RazorPagesAssignment1Context _context;

        public EditModel(RazorPagesAssignment1.Data.RazorPagesAssignment1Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsExists(Details.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DetailsExists(int id)
        {
            return _context.Details.Any(e => e.ID == id);
        }
    }
}
