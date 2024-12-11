namespace BeChinhPhucToan_BE.Models
{
    public class Comment : BaseEntity
    {
        public int exerciseID { get; set; }
        public Excercise? Excercise { get; set; }
        public int studentID { get; set; }
        public Student? Student { get; set; }

        public string comment {  get; set; }
    }
}
