namespace BeChinhPhucToan_BE.Models
{
    public class Lesson : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }

        public int chapterID { get; set; }
        public Chapter? Chapter { get; set; }
    }
}
