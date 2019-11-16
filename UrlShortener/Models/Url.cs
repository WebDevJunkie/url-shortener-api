namespace UrlShortener.Models
{
    public class Url
    {
        public int Id { get; set; }

        public string Redirect { get; set; }

        public string Description { get; set; }
    }
}
