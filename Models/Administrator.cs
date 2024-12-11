using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    public class Administrator : BaseEntity
    {
        [Key]
        public string email { get; set; }
        public string fullName { get; set; }        

        [ForeignKey(nameof(User))]
        public string phoneNumber { get; set; } // Khóa ngoại
        public User User { get; set; }
    }
}
