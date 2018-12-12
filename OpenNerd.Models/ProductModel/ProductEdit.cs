using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNerd.Data;

namespace OpenNerd.Models
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        public int AuthorId { get; set; }
        public int Volume { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
    }
}
