using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesAssignment1.Pages.Students
{
    public class SearchModel : PageModel
    {
        private readonly  DetailsModel _context;
        public IList<DetailsModel> Student
        {
            get; set;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
 public  SearchModel (DetailsModel context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
        }
        public void OnGet()
        {
        }
    }
}
