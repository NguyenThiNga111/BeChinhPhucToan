using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    public class Goal : BaseEntity
    {
        public int id { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public int numberLesson { get; set; }
        public string typeLesson { get; set; }
        public int badgeID { get; set; }

        public int studentID { get; set; }
        public Student? Student { get; set; }
    }
}
