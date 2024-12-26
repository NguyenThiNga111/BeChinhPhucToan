namespace BeChinhPhucToan_BE.Models
{
    public class Exercise : BaseEntity
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public int lessonID { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
