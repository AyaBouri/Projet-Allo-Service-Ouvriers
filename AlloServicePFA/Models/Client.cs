namespace AlloServicePFA.Models
{
    public class Client:User
    {
        public int ClientId { get; set; }
        List<Review> reviews { get; set; }
    }
}