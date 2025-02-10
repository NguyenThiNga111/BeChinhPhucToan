using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    public class Student : BaseEntity
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string? image { get; set; }
        public DateOnly dateOfBirth { get; set; }
        public int grade { get; set; }
        //public bool isTest { get; set; }

        public string userId { get; set; }
        public User? User { get; set; }
        public Setting? Setting { get; set; }
    }
}
