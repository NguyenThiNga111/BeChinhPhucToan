using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeChinhPhucToan_BE.Models
{
    public class Parent : BaseEntity
    {
        [Key]
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string fullName { get; set; }
        public string guardian { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
