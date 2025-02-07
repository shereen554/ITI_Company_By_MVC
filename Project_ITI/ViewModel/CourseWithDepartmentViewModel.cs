using Microsoft.AspNetCore.Mvc;
using Project_ITI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ITI.ViewModel
{
    public class CourseWithDepartmentViewModel
    {
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        [Range(minimum: 50, maximum: 100, ErrorMessage = "Degree shoud range 50 to 100")]
        public decimal Degree { get; set; }
        [Remote("checkMinDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree Shoud less than Degree ")]
        public decimal MinDegree { get; set; }
        [Remote("CheckHour", "Course", "Hourse is invaled ")]
        public int Hours { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public List<Department>? departments { get; set; }

    }
}
