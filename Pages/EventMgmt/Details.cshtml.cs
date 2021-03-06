﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using udemy_web_project_01.Model;

namespace udemy_web_project_01.Pages.EventMgmt
{
    public class DetailsModel : PageModel
    {
        private readonly udemy_web_project_01.Model.ApplicationDBContext _context;

        public DetailsModel(udemy_web_project_01.Model.ApplicationDBContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
