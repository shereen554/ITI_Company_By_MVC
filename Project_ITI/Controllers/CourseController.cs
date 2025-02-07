using Microsoft.AspNetCore.Mvc;
using Project_ITI.Models;
using Project_ITI.Reposatry;
using Project_ITI.ViewModel;

namespace Project_ITI.Controllers
{
    public class CourseController : Controller
    {
        // ITIContext db = new ITIContext();

        ICourseReposatry courseReposatry;
        IDepartmentReposatry departmentReposatry;
        public CourseController(IDepartmentReposatry departmentReposatry,ICourseReposatry courseReposatry)
        {
            this.departmentReposatry = departmentReposatry; 
            this.courseReposatry = courseReposatry;
        }


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
            var course = courseReposatry.GetAll();
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
                //viewModel.DepartmentName = db.Departments.SingleOrDefault(n => n.Id == courseViewModel.DepartmentId).Name;
                viewModel.DepartmentName=departmentReposatry.GetById((int)courseViewModel.DepartmentId).Name;
                viewModel.departments = departmentReposatry.GetAll();
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
            viewModel.departments = departmentReposatry.GetAll();

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
                   courseReposatry.Add(course);
                    courseReposatry.SaveChange();
                    return RedirectToAction("Index", AllCourse());
                }
                catch (Exception ex) 
                {
                      ModelState.AddModelError("DepartmentId", "Please Select DEpartment");
                }
            }
            viewModel.departments=departmentReposatry.GetAll();
            return View("New",viewModel);
        }
    }
}
