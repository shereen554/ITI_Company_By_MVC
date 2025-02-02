using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ITI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }    
        public decimal MinDegree { get; set; }
        public int Hours { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual  Department? Department { get; set; }
        //navegation one to many
        public virtual List<Instractor> Instractors { get;  }=new List<Instractor>();

        public virtual List<CrsREsult> CrsREsults { get; }=new List<CrsREsult>();
    }
}
