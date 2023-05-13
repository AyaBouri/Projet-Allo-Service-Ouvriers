namespace AlloServicePFA.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Rating { get; set; }
        Client client { get; set; }
        public int ClientId { get; set; }
    }
}