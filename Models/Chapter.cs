namespace BeChinhPhucToan_BE.Models
{
    public class Chapter : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }

        public int courseID { get; set; }
        public Course? Course { get; set; }
    }
}
