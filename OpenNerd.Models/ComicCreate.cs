using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalParadise.Models
{
    public class ComicCreate
    {
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}