namespace BeChinhPhucToan_BE.Models
{
    public class Course : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int grade { get; set; }
        public string status { get; set; }

        public ICollection<Chapter>? Chapters { get; set; }
    }
}
