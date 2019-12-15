using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using udemy_web_project_01.Model;

namespace udemy_web_project_01.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        [BindProperty]
        public Book Book { get; set; }

        public UpsertModel(ApplicationDBContext db)
        {
            _db = db;
        }

        /// <summary>
        /// the id is changed to int? nullable as this page is used for both create & insert records, so for new rec, there
        /// is no ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();

            if (id == null)
                return Page(); //for create

            Book = await _db.Book.FirstOrDefaultAsync(u => u.id == id); //for update

            if (Book == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.id == 0) //create
                    _db.Book.Add(Book);
                else
                    _db.Book.Update(Book);

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();

        }
    }
}