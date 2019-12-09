using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using udemy_web_project_01.Model;

namespace udemy_web_project_01.Pages.ConfigMgmt
{
    public class EditModel : PageModel
    {
        private readonly udemy_web_project_01.Model.ApplicationDBContext _context;

        public EditModel(udemy_web_project_01.Model.ApplicationDBContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Config).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigExists(Config.id))
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

        private bool ConfigExists(int id)
        {
            return _context.Config.Any(e => e.id == id);
        }
    }
}
