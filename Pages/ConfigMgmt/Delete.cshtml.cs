using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using udemy_web_project_01.Model;

namespace udemy_web_project_01.Pages.ConfigMgmt
{
    public class DeleteModel : PageModel
    {
        private readonly udemy_web_project_01.Model.ApplicationDBContext _context;

        public DeleteModel(udemy_web_project_01.Model.ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Config Config { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Config = await _context.Config.FirstOrDefaultAsync(m => m.id == id);

            if (Config == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Config = await _context.Config.FindAsync(id);

            if (Config != null)
            {
                _context.Config.Remove(Config);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
