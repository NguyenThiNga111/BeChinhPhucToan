namespace BeChinhPhucToan_BE.Models
{
    public class NotifyStudent : BaseEntity
    {
        public int studentID { get; set; }
        public Student? Student { get; set; }
        public int notificationID { get; set; }
        public ParentNotification? ParentNotification { get; set; }
    }
}
