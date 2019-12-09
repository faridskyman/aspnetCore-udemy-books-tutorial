using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using udemy_web_project_01.Model;

namespace udemy_web_project_01.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        
        [BindProperty]
        public Book Book { get; set; }
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //get the book from db
                var bookFromDB = await _db.Book.FindAsync(Book.id);
                bookFromDB.Name = Book.Name;
                bookFromDB.Author = Book.Author;
                bookFromDB.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}