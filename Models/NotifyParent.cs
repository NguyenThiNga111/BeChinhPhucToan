using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(parentEmail), nameof(notificationID))]
    public class NotifyParent : BaseEntity
    {
        public string parentEmail { get; set; }
        public Parent? Parent { get; set; }
        public int notificationID { get; set; }
        public ParentNotification? ParentNotification { get; set; }
    }
}
