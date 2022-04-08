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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAssignment1.Data.RazorPagesAssignment1Context _context;

        public IndexModel(RazorPagesAssignment1.Data.RazorPagesAssignment1Context context)
        {
            _context = context;
        }

        public IList<Details> Details { get;set; }

        public async Task OnGetAsync()
        {
            var result = (from s in _context.Details
                          select s).Count();
            ViewData["Count"] = $"There are {result} students in the database";
            Details = await _context.Details.ToListAsync();
        }
    }
}
