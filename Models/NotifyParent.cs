using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(notificationID), nameof(parentEmail))]
    public class NotifyParent : BaseEntity
    {
        public string parentEmail { get; set; }

        [JsonIgnore] // Chỉ ẩn Parent khỏi JSON, không ẩn ParentNotification
        public Parent? Parent { get; set; }

        public int notificationID { get; set; }
        //[JsonIgnore]
        public ParentNotification? ParentNotification { get; set; }
    }
}
