using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(notificationID), nameof(studentID))]
    public class NotifyStudent : BaseEntity
    {
        public int studentID { get; set; }
        public Student? Student { get; set; }
        public int notificationID { get; set; }
        public ParentNotification? ParentNotification { get; set; }
    }
}
