namespace DigitGallery.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Drawing
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public double Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
