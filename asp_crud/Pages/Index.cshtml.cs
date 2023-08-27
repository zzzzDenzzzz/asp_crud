using asp_crud.Data;
using asp_crud.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_crud.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        readonly AppDbContext _context;

        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Books = _context.Books.ToList();
            Authors = _context.Authors.ToList();
        }

        public IActionResult Delete(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();
            _context.Books.Remove(book);

            return Page();
        }
    }
}