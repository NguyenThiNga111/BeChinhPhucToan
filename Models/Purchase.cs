namespace BeChinhPhucToan_BE.Models
{
    public class Purchase : BaseEntity
    {
        public int badgeID { get; set; }
        public Badge? Badge { get; set; }
        public int studentID { get; set; }
        public Student? Student { get; set; }
    }
}
