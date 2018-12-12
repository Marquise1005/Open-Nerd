
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenNerd.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public int Volume { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public virtual Author Author { get; set; }

     
        public DateTimeOffset? ModifiedUtc { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
        public enum Genre
        {
        [Display(Name = "Sciencefiction")]
            Sciencefiction,
        [Display(Name = "Satire")]
             Satire,
        [Display(Name = "Drama")]
            Drama,
        [Display(Name = "Action")]
        Action,
        [Display(Name = "Adventure")]
        Adventure,
        [Display(Name = "Romance")]
        Romance,
        [Display(Name = "Mystery")]
        Mystery,
        [Display(Name = "Horror")]
        Horror,
        [Display(Name = "SelfHelp")]
        SelfHelp,
        [Display(Name = "Health")]
        Health,
        [Display(Name = "Guide")]
        Guide,
        [Display(Name = "Travel")]
        Travel,
        [Display(Name = "Children")]
        Children,
        [Display(Name = "Religion")]
        Religion,
        [Display(Name = "Science")]
        Science,
        [Display(Name = "History")]
        History,
        [Display(Name = "Math")]
        Math,
        [Display(Name = "Anthology")]
        Anthology,
        [Display(Name = "Poetry")]
        Poetry,
        [Display(Name = "Encyclopedias")]
        Encyclopedias,
        [Display(Name = "Dictionaries")]
        Dictionaries,
        [Display(Name = "Comics")]
        Comics,
        [Display(Name = "Art")]
        Art,
        [Display(Name = "CookBooks")]
        Cookbooks,
        [Display(Name = "Diaries")]
        Diaries,
        [Display(Name = "Journals")]
        Journals,
        [Display(Name = "Series")]
        Series,
        [Display(Name = "Trilogy")]
        Trilogy,
        [Display(Name = "Biographies")]
        Biographies,
        [Display(Name = "Autobiographies")]
        Autobiographies,
        [Display(Name = "Fantasy")]
        Fantasy
        }
}
      
