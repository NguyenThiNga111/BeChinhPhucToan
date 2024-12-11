namespace BeChinhPhucToan_BE.Models
{
    public class RankedScore : BaseEntity
    {
        public int studentID { get; set; }
        public Student Student { get; set; }
        public int rateTypeID { get; set; }
        public RateType RateType { get; set; }
        public float score { get; set; }

    }
}
