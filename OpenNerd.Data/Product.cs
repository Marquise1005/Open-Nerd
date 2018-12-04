
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenNerd.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public int Issue { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}