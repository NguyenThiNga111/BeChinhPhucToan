using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeChinhPhucToan_BE.Models
{
    public class Administrator : BaseEntity
    {
        [Key]
        public string userId { get; set; }
        [ForeignKey("userId")]
        public User? User { get; set; }
        public string fullName { get; set; }        
    }
}
