using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ITI.Models
{
    [PrimaryKey(nameof(CourseId),nameof(TraineeId))]
    public class CrsREsult
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public decimal Degree { get;set; }

        public virtual Trainee Trainee { get; set; }

        public virtual Course Course { get; set; }
    }
}
