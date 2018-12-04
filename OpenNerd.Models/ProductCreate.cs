using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenNerd.Models
{
    public class ProductCreate
    {
        [Required]
        public string Title { get; set; }

        public int Issue { get; set; }

        public string AuthorName { get; set; }

        public string Type { get; set; }


        public override string ToString() => Title;
    }
}