﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    public class Feedback : BaseEntity
    {
        public int id { get; set; }
        public int ratting { get; set; }
        public string message { get; set; }

        public string userId { get; set; }
        public User? User { get; set; }
    }
}
