using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNerd.Data;

namespace OpenNerd.Models
{
    public class AuthorDetail
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
       

        public override string ToString() => $"[{AuthorId}] {AuthorName}";
    }
}
