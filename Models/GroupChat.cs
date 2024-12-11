namespace BeChinhPhucToan_BE.Models
{
    public class GroupChat : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }

        public IList<JoinGroup> JoinGroup { get; set; }
        public IList<Message> Messages { get; set; }
    }
}
