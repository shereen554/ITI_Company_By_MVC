using Project_ITI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ITI.ViewModel
{
    public class CourseWithDepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }
        public int Hours { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Department> departments { get; set; }

    }
}
