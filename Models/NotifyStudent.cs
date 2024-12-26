using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(notificationID), nameof(studentID))]
    public class NotifyStudent : BaseEntity
    {
        public int studentID { get; set; }
        public Student? Student { get; set; }
        [ForeignKey(nameof(StudentNotification))]
        public int notificationID { get; set; }
        public StudentNotification? StudentNotification { get; set; }
    }
}
