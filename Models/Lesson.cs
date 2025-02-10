using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Models
{   
    public class Lesson : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }        

        public int lessonTypeID { get; set; }
        public LessonType? LessonType { get; set; }
    }
}
