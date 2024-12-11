namespace BeChinhPhucToan_BE.Models
{
    public class ParentNotification : BaseEntity
    {
        public int id { get; set; }
        public string message { get; set; }
        public bool isRead { get; set; }
        public IList<NotifyParent>? NotifyParents { get; set; }
    }
}
