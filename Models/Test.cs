namespace BeChinhPhucToan_BE.Models
{
    public class Test : BaseEntity
    {
        public int id { get; set; }
        public int grade { get; set; }
        public int code { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}
