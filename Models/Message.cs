using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(groupID), nameof(studentID))]
    public class Message : BaseEntity
    {
        public int groupID { get; set; }
        public GroupChat? GroupChat { get; set; }
        public int studentID { get; set; }
        public Student? Student { get; set; }
        public string message { get; set; }
        public DateTime sentDate { get; set; }
    }
}
