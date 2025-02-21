using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ITI.Models
{
    public class Instractor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [HiddenInput]
        public string ImagUrl { get; set; }
        [NotMapped]
        public IFormFile ImgFom { get; set; }

        public decimal Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }

    }
}
