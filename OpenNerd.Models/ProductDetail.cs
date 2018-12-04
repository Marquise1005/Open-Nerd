﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenNerd.Models
{
        public class ProductDetail
        {
            public int ProductId { get; set; }
            public string Title { get; set; }
            public string AuthorName { get; set; }
             public int Issue { get; set; }
             public string Type { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{ProductId}] {Title}";
        }
    }