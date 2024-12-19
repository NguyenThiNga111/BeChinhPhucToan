using System.Text.Json.Serialization;

namespace BeChinhPhucToan_BE.Models
{
    public class ParentNotification : BaseEntity
    {
        public int id { get; set; }
        public string message { get; set; }
        public bool isRead { get; set; }

        // Sửa thành ICollection để tương thích tốt hơn với EF Core
        [JsonIgnore]
        public ICollection<NotifyParent>? NotifyParents { get; set; }
    }
}
