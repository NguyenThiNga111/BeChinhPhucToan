using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BeChinhPhucToan_BE.Models
{
    public class Administrator : BaseEntity
    {
        [Key]
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string fullName { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
