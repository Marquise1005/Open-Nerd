﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenNerd.Models
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }

        public int ProductId { get; set; }

        public string Title { get; set; }

        public int Qauntity { get; set; }

        public int Price { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
