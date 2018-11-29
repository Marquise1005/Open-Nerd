
using System;
using System.ComponentModel.DataAnnotations;

namespace OpenNerd.Data
{
    public class Comic
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Content { get; set; }



        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}