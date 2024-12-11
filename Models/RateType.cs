namespace BeChinhPhucToan_BE.Models
{
    public class RateType : BaseEntity
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<RankedTest> RankedTests { get; set; }
        public IList<RankedScore> RankedScores { get; set; }
    }
}
