using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    public class Student : BaseEntity
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string image { get; set; }
        public DateOnly dateOfBirth { get; set; }
        public int grade { get; set; }

        [ForeignKey(nameof(Parent))]
        public string parentPhone { get; set; }
        public Parent? Parent { get; set; }
        public Setting? Setting { get; set; }
    }
}
