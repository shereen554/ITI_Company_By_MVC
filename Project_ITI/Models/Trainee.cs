using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ITI.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public decimal grade { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual List<CrsREsult>CrsREsults { get; }=new List<CrsREsult>();
    }
}
