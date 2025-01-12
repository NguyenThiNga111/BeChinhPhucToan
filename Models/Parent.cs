using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeChinhPhucToan_BE.Models
{
    public class Parent : BaseEntity
    {
        [Key]
        public string userId { get; set; }
        public string fullName { get; set; }
        public string guardian { get; set; }
    }
}
