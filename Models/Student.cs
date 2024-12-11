using System.ComponentModel.DataAnnotations.Schema;

namespace BeChinhPhucToan_BE.Models
{
    public class Student : BaseEntity
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string image { get; set; }
        public DateOnly dateOfBirth { get; set; }
        public int grade { get; set; }

        [ForeignKey(nameof(Parent))]
        public string parentEmail { get; set; }
        public Parent? Parent { get; set; }
        public Setting? Setting { get; set; }

        public ICollection<Reward>? Rewards { get; set; }
        public ICollection<Goal>? Goals { get; set; }
        public IList<Purchase>? Purchase { get; set; }
        public IList<JoinGroup>? JoinGroup { get; set; }
        public IList<Message>? Messages { get; set; }     
        public IList<NotifyStudent>? NotifyStudent { get; set; }
        public IList<RankedScore>? RankedScores { get; set; }
        public IList<StarPoint>? StarPoints { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}
