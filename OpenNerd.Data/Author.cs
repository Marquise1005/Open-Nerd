using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenNerd.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        [Required]
        public string AuthorName { get; set; }


        public int Age { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
    public enum Gender
    {
        //[Display(Name="Male")]
        Male,

        //[Display(Name="Female")]
        Female
    }
}