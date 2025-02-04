using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            List<INstractorDeptCourse> InstractorDeptCoursesModel = new List<INstractorDeptCourse>();
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

            HttpContext.Session.SetString("InstractorDeptCoursesModel", JsonConvert.SerializeObject(InstractorDeptCoursesModel));
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

        public IActionResult Edit(int id) 
        {
           var instractor =ITIContext.Instractors.FirstOrDefault(n => n.Id == id);
            InstractorWithDeptAndCourseListModelView viewModel = new InstractorWithDeptAndCourseListModelView();
            var departments=ITIContext.Departments.ToList();
            var Courses=ITIContext.Courses.ToList();
            if (instractor != null)
            {
                viewModel.Id = instractor.Id;
                viewModel.Name = instractor.Name;
                viewModel.Address = instractor.Address;
                viewModel.ImagUrl = instractor.ImagUrl;
                viewModel.Salary = instractor.Salary;
                viewModel.DepartmentList = departments;
                viewModel.CourseList = Courses;  
            }
            return View("Edit",viewModel);
        }
        [HttpPost]
        public IActionResult SaveEdit(InstractorWithDeptAndCourseListModelView viewmodel) 
        {
            if (viewmodel.Name != null && viewmodel.ImagUrl != null && viewmodel.Salary != null && viewmodel.Address != null)
            {
                Instractor instractor =ITIContext.Instractors.FirstOrDefault(n=>n.Id==viewmodel.Id);

                    instractor.Name = viewmodel.Name;
                    instractor.Address = viewmodel.Address;
                    instractor.ImagUrl= viewmodel.ImagUrl;
                    instractor.Salary = viewmodel.Salary;
                    instractor.DepartmentId=viewmodel.DepartmentId;
                    instractor.CourseId=viewmodel.CourseId;
                    ITIContext.SaveChanges();

                //InstractorDeptCoursesModel
                var sessionData = HttpContext.Session.GetString("InstractorDeptCoursesModel");

                 var  model = JsonConvert.DeserializeObject<List<INstractorDeptCourse>>(sessionData);

                return RedirectToAction("Index",model);
            }
            viewmodel.DepartmentList=ITIContext.Departments.ToList();
            viewmodel.CourseList=ITIContext.Courses.ToList();
            return View("Edit", viewmodel);
        }

        
    }
}
