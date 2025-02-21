using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using Project_ITI.Models;
using Project_ITI.Reposatry;
using Project_ITI.ViewModel;

namespace Project_ITI.Controllers
{
    public class InstractorController : Controller
    {
        //ITIContext ITIContext =new ITIContext();

        IInstractorReposatry instractorReposatry;
        ICourseReposatry courseReposatry;
        IDepartmentReposatry departmentReposatry;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InstractorController(IWebHostEnvironment webHostEnvironment, IInstractorReposatry instractorReposatry, ICourseReposatry courseReposatry, IDepartmentReposatry departmentReposatry)
        {
            _webHostEnvironment = webHostEnvironment;
            this.instractorReposatry = instractorReposatry;
            this.courseReposatry = courseReposatry;
            this.departmentReposatry = departmentReposatry;
        }

        public List<INstractorDeptCourse> All()
        {
            List<Instractor> Instractors = instractorReposatry.GetAll();

            List<INstractorDeptCourse> InstractorDeptCoursesModel = new List<INstractorDeptCourse>();
            foreach (var item in Instractors)
            {
                var ins = new INstractorDeptCourse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    ImagUrl = item.ImagUrl,
                    Salary = item.Salary,
                    CourseName = courseReposatry.GetCourseName((int)item.CourseId),
                    DepartmentName = departmentReposatry.GetDepartmentName((int)item.DepartmentId)
                };
                InstractorDeptCoursesModel.Add(ins);

            }
            HttpContext.Session.SetString("InstractorDeptCoursesModel", JsonConvert.SerializeObject(InstractorDeptCoursesModel));
            return InstractorDeptCoursesModel;

        }
        public IActionResult Index()
        {

            return View("Index", All());
        }


        public INstractorDeptCourse Showdetails(int id)
        {
            Instractor InstractorModel = instractorReposatry.GetById(id);
            INstractorDeptCourse InstractorDeptCourse = new INstractorDeptCourse()
            {
                Id = InstractorModel.Id,
                Name = InstractorModel.Name,
                Address = InstractorModel.Address,
                ImagUrl = InstractorModel.ImagUrl,
                Salary = InstractorModel.Salary,
                CourseName = courseReposatry.GetCourseName((int)InstractorModel.CourseId),
                DepartmentName = departmentReposatry.GetDepartmentName((int)InstractorModel.DepartmentId)
            };
            return InstractorDeptCourse;
        }
        public IActionResult Details(int id)
        {
            return View("Details", Showdetails(id));
        }

        //Search
        public IActionResult Search(string name)
        {
            List<Instractor>instractors =instractorReposatry.Search(name);

            List<INstractorDeptCourse> InstractorDeptCoursesModel = new List<INstractorDeptCourse>();
            foreach (var item in instractors)
            {
                var ins = new INstractorDeptCourse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    ImagUrl = item.ImagUrl,
                    Salary = item.Salary,
                    CourseName = courseReposatry.GetCourseName((int)item.CourseId),
                    DepartmentName = departmentReposatry.GetDepartmentName((int)item.DepartmentId)
                };
                InstractorDeptCoursesModel.Add(ins);

            }
            return View("Search",InstractorDeptCoursesModel);  //Method and id
        }



        public IActionResult Edit(int id) 
        {
           var instractor =instractorReposatry.GetById(id);
            InstractorWithDeptAndCourseListModelView viewModel = new InstractorWithDeptAndCourseListModelView();
            var departments=departmentReposatry.GetAll();
            var Courses=courseReposatry.GetAll();
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
                Instractor instractor = instractorReposatry.GetById(viewmodel.Id);

                    instractor.Name = viewmodel.Name;
                    instractor.Address = viewmodel.Address;
                    instractor.ImagUrl= viewmodel.ImagUrl;
                    instractor.Salary = viewmodel.Salary;
                    instractor.DepartmentId=viewmodel.DepartmentId;
                    instractor.CourseId=viewmodel.CourseId;

                     instractorReposatry.SaveChange();

                //InstractorDeptCoursesModel
                var sessionData = HttpContext.Session.GetString("InstractorDeptCoursesModel");

                 var  model = JsonConvert.DeserializeObject<List<INstractorDeptCourse>>(sessionData);

                return RedirectToAction("Index",model);
            }
            viewmodel.DepartmentList=departmentReposatry.GetAll();
            viewmodel.CourseList=courseReposatry.GetAll();
            return View("Edit", viewmodel);
        }

        public IActionResult NewInstractor()
        {

            InstractorWithDeptAndCourseListModelView viewmodel=new InstractorWithDeptAndCourseListModelView();
            viewmodel.DepartmentList = departmentReposatry.GetAll();
            viewmodel.CourseList = courseReposatry.GetAll();

                return View("NewInstractor", viewmodel);

        }


        //Check Department 
        public IActionResult GetCoursesByDepartment(int departmentId)
        {
            List<Course> courses = courseReposatry.GetByDeptIt(departmentId);
            return Json(courses);
        }

        //Delete
        public IActionResult Delete(int id)
        {
           int rowAffect= instractorReposatry.Delete(id);
            ViewData["rowAffect"]=rowAffect;
            if(rowAffect==1)
            {
                instractorReposatry.SaveChange();
            }
            return View("Index",All());

        }


      


        [HttpPost]
        public IActionResult SaveNew(InstractorWithDeptAndCourseListModelView viewmodel)
        {

            if(ModelState.IsValid)
            {
                //Upload Image -----------------Start
                //path
                string FileName=Path.GetFileNameWithoutExtension(viewmodel.ImgFom.FileName);
                string extention=Path.GetExtension(viewmodel.ImgFom.FileName);
                string uniqueFile =FileName +"_"+Guid.NewGuid().ToString().Substring(0,5)+extention;

                //المكان اللي عاوزه احفظه فيه  www.root
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath,"Images");

                //اجيب بقا الباص كلو  
                string filePath = Path.Combine(uploadsFolder, uniqueFile);
                //
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewmodel.ImgFom.CopyTo(fileStream);
                }


                //Upload Image -----------------End

                Instractor instractor = new Instractor()
                {
                    Name = viewmodel.Name,
                    Address = viewmodel.Address,
                    CourseId = viewmodel.CourseId,
                    Salary = viewmodel.Salary,
                    ImagUrl = uniqueFile,
                    DepartmentId = viewmodel.DepartmentId,
                };
               instractorReposatry.Add(instractor);
                instractorReposatry.SaveChange();

                
                return RedirectToAction("Index",All());
            }
            viewmodel.CourseList = courseReposatry.GetAll();
            viewmodel.DepartmentList = departmentReposatry.GetAll();

            return View("NewInstractor",viewmodel);
        }

        
    }
}
