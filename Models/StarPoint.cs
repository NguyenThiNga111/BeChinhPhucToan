using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(lessonID), nameof(studentID))]
    public class StarPoint : BaseEntity
    {
        public int lessonID { get; set; }
        public Lesson? Lesson { get; set; }
        public int studentID { get; set; }
        public Student? Student { get; set; }
        public int star { get; set; }
    }
}
