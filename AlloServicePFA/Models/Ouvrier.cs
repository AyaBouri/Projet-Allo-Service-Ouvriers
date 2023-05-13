namespace AlloServicePFA.Models
{
    public class Ouvrier:User
    {
        public int OuvrierId { get; set; }
        List<Service> services { get; set; }
    }
}