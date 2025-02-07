using Microsoft.AspNetCore.Mvc;
using Project_ITI.Models;
using Project_ITI.ViewModel;

namespace Project_ITI.Controllers
{
    public class CourseController : Controller
    {
        ITIContext db = new ITIContext();


        public IActionResult CheckHour(int hours)
        {
            if(hours%3==0)
            {
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult checkMinDegree(decimal mindegree ,decimal degree)
        {
            if(mindegree<degree)
            {
                return Json(true);
            }
            return Json(false);
        }

        public List<CourseWithDepartmentViewModel> AllCourse()
        {
            List<CourseWithDepartmentViewModel> viewModels = new List<CourseWithDepartmentViewModel>();
            var course = db.Courses.ToList();
            foreach (var courseViewModel in course)
            {
                CourseWithDepartmentViewModel viewModel = new CourseWithDepartmentViewModel()
                {
                    Name = courseViewModel.Name,
                    Degree = courseViewModel.Degree,
                    MinDegree = courseViewModel.MinDegree,
                    Hours = courseViewModel.Hours,
                    DepartmentId = courseViewModel.DepartmentId,
                };
                viewModel.DepartmentName = db.Departments.SingleOrDefault(n => n.Id == courseViewModel.DepartmentId).Name;
                viewModel.departments = db.Departments.ToList();
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
        public IActionResult Index()
        {
            return View("Index",AllCourse());
            
        }
        [HttpGet]
        public IActionResult New()
        {
            CourseWithDepartmentViewModel viewModel = new CourseWithDepartmentViewModel();
            viewModel.departments=db.Departments.ToList();

            return View("New", viewModel);
        }
        [HttpPost]
        public IActionResult SaveNew(CourseWithDepartmentViewModel viewModel) 
        {
            
            //if(viewModel.Degree !=null && viewModel.MinDegree !=null &&  viewModel.Hours !=null && viewModel.Name !=null)
            //{
            if(ModelState.IsValid)
            {
                try
                {

                    Course course = new Course()
                    {
                        Name = viewModel.Name,
                        Degree = viewModel.Degree,
                        Hours = viewModel.Hours,
                        MinDegree = viewModel.MinDegree,
                        DepartmentId = viewModel.DepartmentId,
                    };
                    db.Courses.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("Index", AllCourse());
                }
                catch (Exception ex) 
                {
                      ModelState.AddModelError("DepartmentId", "Please Select DEpartment");
                }
            }
            viewModel.departments=db.Departments.ToList();
            return View("New",viewModel);
        }
    }
}
