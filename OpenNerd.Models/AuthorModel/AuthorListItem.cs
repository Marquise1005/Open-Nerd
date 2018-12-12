using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNerd.Data;

namespace OpenNerd.Models
{
   public class AuthorListItem
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public int Age { get; set; }

        public Gender Gender { get; set; }


        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
