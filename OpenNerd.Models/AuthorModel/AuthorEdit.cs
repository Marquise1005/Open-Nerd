using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNerd.Data;

namespace OpenNerd.Models
{
   public class AuthorEdit
    {    
        public int AuthorId { get; set; }

      
        public string AuthorName { get; set; }

       
        public int Age { get; set; }

        public Gender Gender { get; set; }
    }
}
