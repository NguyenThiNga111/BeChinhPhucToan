namespace BeChinhPhucToan_BE.Models
{
    public class RankedTest : BaseEntity
    {
        public int id { get; set; }
        public int grade { get; set; }
        public string question { get; set; }
        public string answer { get; set; }

        public int rateTypeID { get; set; }
        public RateType? RateType { get; set; }
    }
}
