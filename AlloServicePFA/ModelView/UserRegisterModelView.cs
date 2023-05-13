using System.ComponentModel.DataAnnotations;
namespace AlloServicePFA.ModelView
{
    public class UserRegisterModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Le prenom est obligatoire")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "L'email est obligatoire")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le Login est obligatoire")]
        public string Login { get; set; }
        [MinLength(6, ErrorMessage = "Le password > 6 caractére")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Les 2 passwords doivent etre equi")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}