using asp_crud.Data;
using asp_crud.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace asp_crud.Pages
{
    [BindProperties]
    public class CreateAuthorModel : PageModel
    {
        readonly AppDbContext _context;

        public CreateAuthorModel(AppDbContext context)
        {
            _context = context;
        }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Имя автора:")]
        public string FirstNameAuthor { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Фамилия автора:")]
        public string LastNameAuthor { get; set; }

        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения автора:")]
        public DateTime BirthDateAuthor { get; set; }

        public void OnGet()
        {
        }

        public Author newAuthor { get; set; }
        public IActionResult OnPost()
        {
            newAuthor = new()
            {
                FirstName = FirstNameAuthor,
                LastName = LastNameAuthor,
                BirthDate = BirthDateAuthor
            };

            _context.Add(newAuthor);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
