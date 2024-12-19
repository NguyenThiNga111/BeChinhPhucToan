using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeChinhPhucToan_BE.Models
{
    public class Parent : BaseEntity
    {
        [Key]
        public string email { get; set; }
        public string fullName { get; set; }
        public string guardian { get; set; }
        [ForeignKey(nameof(User))]
        public string phoneNumber { get; set; }
        //[JsonIgnore]
        public User? User { get; set; }
        public IList<NotifyParent>? NotifyParents { get; set; }
        //public ICollection<Student>? Students { get; set; }

    }
}
