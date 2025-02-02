using Microsoft.AspNetCore.Mvc;
using Project_ITI.Models;
using Project_ITI.ViewModel;

namespace Project_ITI.Controllers
{
    public class InstractorController : Controller
    {
        ITIContext ITIContext =new ITIContext();
        public IActionResult Index()
        {
            List<Instractor> Instractors =ITIContext.Instractors.ToList();
            List< INstractorDeptCourse > InstractorDeptCoursesModel=new List<INstractorDeptCourse>();

            foreach (var item in Instractors)
            {
                var ins = new INstractorDeptCourse() {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    ImagUrl = item.ImagUrl,
                    Salary = item.Salary,
                    CourseName = ITIContext.Courses.Where(n => n.Id == item.CourseId).Select(n => n.Name).FirstOrDefault(),
                    DepartmentName = ITIContext.Departments.Where(n => n.Id == item.DepartmentId).Select(n => n.Name).FirstOrDefault()
                };
                InstractorDeptCoursesModel.Add(ins);    

            }
            return View("Index", InstractorDeptCoursesModel);
        }
        public IActionResult Details(int id)
        {
            Instractor InstractorModel = ITIContext.Instractors.FirstOrDefault(i => i.Id == id);
            INstractorDeptCourse InstractorDeptCourse=new INstractorDeptCourse()
            {
                Id = InstractorModel.Id,
                Name = InstractorModel.Name,
                Address = InstractorModel.Address,
                ImagUrl = InstractorModel.ImagUrl,
                Salary = InstractorModel.Salary,
                CourseName = ITIContext.Courses.Where(n => n.Id == InstractorModel.CourseId).Select(n => n.Name).FirstOrDefault(),
                DepartmentName = ITIContext.Departments.Where(n => n.Id == InstractorModel.DepartmentId).Select(n => n.Name).FirstOrDefault()
            };

            return View("Details", InstractorDeptCourse);
        }
    }
}
