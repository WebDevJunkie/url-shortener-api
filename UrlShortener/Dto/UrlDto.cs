using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Dto
{
    public class UrlDto
    {
        [Required]
        public string Redirect { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
