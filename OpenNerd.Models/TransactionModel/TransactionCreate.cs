﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenNerd.Models
{
    public class TransactionCreate
    {
        public int ProductId { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
