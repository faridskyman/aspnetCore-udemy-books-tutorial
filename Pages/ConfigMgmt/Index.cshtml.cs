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
    public class IndexModel : PageModel
    {
        private readonly udemy_web_project_01.Model.ApplicationDBContext _context;

        public IndexModel(udemy_web_project_01.Model.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Config> Config { get;set; }

        public async Task OnGetAsync()
        {
            Config = await _context.Config.ToListAsync();
        }
    }
}
