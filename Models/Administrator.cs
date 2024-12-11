using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BeChinhPhucToan_BE.Models
{
    [Index(nameof(email), IsUnique = true)]
    public class Administrator : BaseEntity
    {
        [Key]
        public string phoneNumber { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
    }
}
