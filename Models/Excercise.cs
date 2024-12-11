namespace BeChinhPhucToan_BE.Models
{
    public class Excercise : BaseEntity
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public int lessonID { get; set; }
        public Lesson? Lesson { get; set; }

        public IList<Comment>? Comments { get; set; }
    }
}
