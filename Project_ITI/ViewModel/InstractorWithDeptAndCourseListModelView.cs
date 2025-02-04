using Project_ITI.Models;

namespace Project_ITI.ViewModel
{
    public class InstractorWithDeptAndCourseListModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagUrl { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }

       public List<Department> DepartmentList { get; set; }
       public List<Course> CourseList { get; set; }
    }
}
