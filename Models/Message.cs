namespace BeChinhPhucToan_BE.Models
{
    public class Message : BaseEntity
    {
        public int groupID { get; set; }
        public GroupChat? GroupChat { get; set; }
        public int studentID { get; set; }
        public Student? Student { get; set; }
        public string message { get; set; }
        public DateTime sentDate { get; set; }
    }
}
