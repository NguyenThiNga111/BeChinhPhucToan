namespace BeChinhPhucToan_BE.Models
{
    public class JoinGroup : BaseEntity
    {
        public int groupID { get; set; }
        public GroupChat? GroupChat { get; set; }
        public int studentID { get; set; }
        public Student? Student { get; set; }
        public DateTime joinedDate { get; set; }
        public DateTime leftDate { get; set; }                   
    }
}
