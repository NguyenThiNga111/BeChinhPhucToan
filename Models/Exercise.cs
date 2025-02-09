using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Models
{
    public class Exercise : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isComplete { get; set; }

        public int lessonTypeID { get; set; }
        public LessonType? LessonType { get; set; }

    }
}
