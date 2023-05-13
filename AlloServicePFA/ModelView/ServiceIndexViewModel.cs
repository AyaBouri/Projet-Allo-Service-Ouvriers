using AlloServicePFA.Models;

namespace AlloServicePFA.ModelView
{
    public class ServiceIndexViewModel
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public ServiceIndexViewModel() { }
        public ServiceIndexViewModel(Service service)
        {
            this.Libelle = service.Libelle;
        }
    }
}