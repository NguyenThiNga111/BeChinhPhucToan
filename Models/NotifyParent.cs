using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(parentId), nameof(notificationID))]
    public class NotifyParent : BaseEntity
    {
        public string parentId { get; set; }
        public Parent? Parent { get; set; }

        [ForeignKey(nameof(ParentNotification))]
        public int notificationID { get; set; }
        public ParentNotification? ParentNotification { get; set; }
    }
}
