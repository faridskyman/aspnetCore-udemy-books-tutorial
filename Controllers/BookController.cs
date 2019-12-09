using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using udemy_web_project_01.Model;

namespace udemy_web_project_01.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDBContext _db;

        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDB = await _db.Book.FirstOrDefaultAsync(u => u.id == id);
            if(bookFromDB == null)
            {
                return Json(new { success = false, message = "Book not found, cant delete" });
            }
            _db.Book.Remove(bookFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "book was deleted" });
        }
    }
}