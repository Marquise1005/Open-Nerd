using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNerd.Data;

namespace OpenNerd.Models
{
    public class ProductCreate
    {
        [Required]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        public int AuthorId { get; set; }

        public int Volume { get; set; }

        public override string ToString() => Title;
    }
}