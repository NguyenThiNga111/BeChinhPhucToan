namespace BeChinhPhucToan_BE.Models
{
    public class Question : BaseEntity
    {
        public int id { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string wrongAnswer1 { get; set; }
        public string wrongAnswer2 { get; set; }
        public string wrongAnswer3 { get; set; }
        public string solution { get; set; }


        public int exerciseID { get; set; }
        public Exercise? Exercise { get; set; }
    }
}
