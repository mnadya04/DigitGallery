namespace DigitGallery.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Bio { get; set; }
        public virtual ICollection<Drawing> Drawings { get; set; } = new HashSet<Drawing>();

    }
}
