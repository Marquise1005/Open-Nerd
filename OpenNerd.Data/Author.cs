using System;
using System.ComponentModel.DataAnnotations;

namespace OpenNerd.Data
{
    public class Author
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public Guid AuthorId { get; set; } 

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }



        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}