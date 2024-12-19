using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(parentPhone), nameof(notificationID))]
    public class NotifyParent : BaseEntity
    {
        [ForeignKey(nameof(Parent))]
        public string parentPhone { get; set; }
        public Parent? Parent { get; set; }
        [ForeignKey(nameof(ParentNotification))]
        public int notificationID { get; set; }
        public ParentNotification? ParentNotification { get; set; }
    }
}
