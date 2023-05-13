namespace AlloServicePFA.Models
{
    public class ImgPub
    {
        public int ImgPubId { get; set; }
        public string Chemin { get; set; }
        List<Publication> publications { get; set; }
    }
}