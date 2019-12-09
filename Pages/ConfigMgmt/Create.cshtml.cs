using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using udemy_web_project_01.Model;

namespace udemy_web_project_01.Pages.ConfigMgmt
{
    public class CreateModel : PageModel
    {
        private readonly udemy_web_project_01.Model.ApplicationDBContext _context;

        public CreateModel(udemy_web_project_01.Model.ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Config Config { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Config.Add(Config);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
