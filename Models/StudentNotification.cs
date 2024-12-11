namespace BeChinhPhucToan_BE.Models
{
    public class StudentNotification : BaseEntity
    {
        public int id { get; set; }
        public string message { get; set; }
        public bool isRead { get; set; }
        public IList<NotifyStudent>? NotifyStudent { get; set; }
    }
}
