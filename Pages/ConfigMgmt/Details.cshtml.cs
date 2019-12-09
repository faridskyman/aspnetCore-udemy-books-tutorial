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
    public class DetailsModel : PageModel
    {
        private readonly udemy_web_project_01.Model.ApplicationDBContext _context;

        public DetailsModel(udemy_web_project_01.Model.ApplicationDBContext context)
        {
            _context = context;
        }

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
    }
}
