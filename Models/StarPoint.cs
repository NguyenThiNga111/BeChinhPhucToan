namespace BeChinhPhucToan_BE.Models
{
    public class StarPoint : BaseEntity
    {
        public int lessonID { get; set; }
        public Lesson Lesson { get; set; }
        public int studentID { get; set; }
        public Student Student { get; set; }
        public int star { get; set; }
    }
}
