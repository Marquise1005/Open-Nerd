using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNerd.Data;

namespace OpenNerd.Models
{
    public class AuthorCreate
    {

        [Required]
        public string AuthorName { get; set; }

        
        public int Age { get; set; }


        public Gender Gender { get; set; }

        public override string ToString() => AuthorName;
    }
}
