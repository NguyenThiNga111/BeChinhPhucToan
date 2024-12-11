using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    public class NotifyParent : BaseEntity
    {
        public string parentEmail { get; set; }
        public Parent? Parent { get; set; }
        public int notificationID { get; set; }
        public ParentNotification? ParentNotification { get; set; }
    }
}
