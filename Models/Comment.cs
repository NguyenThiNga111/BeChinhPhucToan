using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BeChinhPhucToan_BE.Models
{
    [PrimaryKey(nameof(excerciseID), nameof(studentID))]
    public class Comment : BaseEntity
    {
        public int excerciseID { get; set; }
        public Excercise? Excercise { get; set; }
        public int studentID { get; set; }
        public Student? Student { get; set; }

        public string comment {  get; set; }
    }
}
