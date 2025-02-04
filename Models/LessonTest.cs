namespace BeChinhPhucToan_BE.Models
{
    public class LessonTest
    {
        public int id { get; set; }
        public int code { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public int lessonTypeID { get; set; }
        public LessonType? LessonType { get; set; }
    }
}
