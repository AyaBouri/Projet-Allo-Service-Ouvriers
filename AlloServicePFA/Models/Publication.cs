namespace AlloServicePFA.Models
{
    public class Publication
    {
        public int PublicationId { get; set; }
        public string Libelle { get; set; }
        public DateTime DatePub { get; set; }
        public string Description { get; set; }
        public string TypePublication { get; set; }
        User user { get; set; }
        public int UserId { get; set; }
    }
}