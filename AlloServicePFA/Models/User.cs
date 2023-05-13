using AlloServicePFA.ModelView;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlloServicePFA.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Ville { get; set; }
        public string Login { get; set; }
        public string password { get; set; }
        [NotMapped]
        public string Path { get; set; }
        //public IFormFile Photo { get; set; }
        public DateTime DateDernierConnection { get; set; }
        List<Publication> publications { get; set; }
        List<Message> messages { get; set; }
        Inscription inscription { get; set; }
        public int InscriptionId { get; set; }
        public string Role { get; set; }
        public User()
        {

        }
        public User(UserRegisterModelView model)
        {
            this.Nom = model.FirstName;
            this.Prenom = model.LastName;
            this.Email = model.Email;
            this.Login = model.Login;
            this.password = model.Password;
        }
    }
}