using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenNerd.Models
{
   public class TransactionEdit
    {
        
        public int TransactionId { get; set; }
   
        public int ProductId { get; set; }

        public int Qauntity { get; set; }

        public int Price { get; set; }

    }
}
