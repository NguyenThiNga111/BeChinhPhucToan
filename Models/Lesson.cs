using Microsoft.EntityFrameworkCore;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(studentID), nameof(lessonTypeID))]
    public class Lesson : BaseEntity
    {
        public int studentID { get; set; }
        public Student? Student { get; set; }
        public int lessonTypeID { get; set; }
        public LessonType? LessonType { get; set; }

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool isComplete { get; set; }
    }
}
