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

        [Required(ErrorMessage = "���� ����������� � ����������")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "��� ������:")]
        public string FirstNameAuthor { get; set; }

        [Required(ErrorMessage = "���� ����������� � ����������")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "������� ������:")]
        public string LastNameAuthor { get; set; }

        [Required(ErrorMessage = "���� ����������� � ����������")]
        [DataType(DataType.Date)]
        [Display(Name = "���� �������� ������:")]
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
