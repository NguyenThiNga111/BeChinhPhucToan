namespace BeChinhPhucToan_BE.Models
{
    public class Question : BaseEntity
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public int exerciseID { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
