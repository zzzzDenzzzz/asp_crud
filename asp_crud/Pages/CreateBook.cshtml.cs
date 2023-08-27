using asp_crud.Data;
using asp_crud.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace asp_crud.Pages
{
    [BindProperties]
    public class CreateBookModel : PageModel
    {
        readonly AppDbContext _context;

        public CreateBookModel(AppDbContext context)
        {
            _context = context;
        }

        [Required(ErrorMessage = "Название обязательно к заполнению")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Название книги:")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Стоимость обязательно к заполнению")]
        [DataType(DataType.Currency)]
        [Display(Name = "Стоимость книги:")]
        public decimal BookPrice { get; set; }

        public string BookAuthor { get; set; }

        public int Pages { get; set; }

        public void OnGet()
        {
        }

        public Book newBook {  get; set; }
        public IActionResult OnPost()
        {
            newBook = new()
            {
                Name = BookName,
                Price = BookPrice,
                Author = BookAuthor,
                PageCount = Pages
            };

            _context.Add(newBook);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
