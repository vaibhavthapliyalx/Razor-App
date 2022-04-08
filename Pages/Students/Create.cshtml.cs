using System;
using System.IO;
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
        [BindProperty]

        public IFormFile UploadPhoto { get; set; }
        [BindProperty]
        public Person Person { get; set; }
        private IHostingEnvironment _environment;
        private string[] permittedExtensions = { ".jpg", ".png" };
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

        public CreateModel(UploadDemo.Data.UploadDemoContext context, IHostingEnvironment
environment)
        {
            _context = context;
            _environment = environment;
        }






        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (UploadPhoto == null)
            {
                ViewData["Error"] = "Select a file";
            }
            else
            {
                var ext = Path.GetExtension(UploadPhoto.FileName.ToLowerInvariant());
                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    ViewData["Error"] = "Invalid file extension";
                }//end if
                else
                {
                    var file = Path.Combine(_environment.ContentRootPath,
                   "wwwroot/Uploads", UploadPhoto.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await UploadPhoto.CopyToAsync(fileStream);
                    }
                    Person.Photo = UploadPhoto.FileName;
                    _context.Person.Add(Person);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }//inner else
            }//outer else
        }

    }
}
