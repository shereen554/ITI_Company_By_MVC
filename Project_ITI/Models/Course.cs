using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ITI.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        [Range(minimum: 50, maximum: 100, ErrorMessage = "Degree shoud range 50 to 100")]
        public decimal Degree { get; set; }
        [Remote("checkMinDegree","Course",AdditionalFields ="Degree",ErrorMessage ="MinDegree Shoud less than Degree ")]
        public decimal MinDegree { get; set; }
        [Remote("CheckHour","Course","Hourse is invaled ")]
        public int Hours { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public virtual  Department? Department { get; set; }
        //navegation one to many
        public virtual List<Instractor> Instractors { get;  }=new List<Instractor>();

        public virtual List<CrsREsult> CrsREsults { get; }=new List<CrsREsult>();
    }
}
