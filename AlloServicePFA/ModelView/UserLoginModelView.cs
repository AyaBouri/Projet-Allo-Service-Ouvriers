using System.ComponentModel.DataAnnotations;

namespace AlloServicePFA.ModelView
{
    public class UserLoginModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Le logine est obligatoire")]
        public string Login { get; set; }
        [MinLength(6,ErrorMessage ="Le password > 6")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}