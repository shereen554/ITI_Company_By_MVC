using Microsoft.AspNetCore.Mvc;
using Project_ITI.Models;
using Project_ITI.ViewModel;

namespace Project_ITI.Controllers
{
    public class TraineeController : Controller
    {
        ITIContext db=new ITIContext();
        public IActionResult Result(int crsId,int traineeId)
        {

            CrsREsult crsREsults=db.CrsREsults.SingleOrDefault(n=>n.CourseId==crsId&&n.TraineeId==traineeId);  // crsId traine  degree
            CrsTraineeViewModel model = new CrsTraineeViewModel();
            decimal degreeSucess=0;
            if (crsREsults!=null) 
            {
                Course course = db.Courses.SingleOrDefault(n => n.Id == crsId);
                Trainee trainee = db.Trainees.SingleOrDefault(n => n.Id == traineeId);
       
                model.TraineeId = traineeId;
                model.TraineeName = trainee.Name;
                model.CourseName = course.Name;
                model.Degree = crsREsults.Degree;
                // store Succes degree
                 degreeSucess =course.MinDegree;
            }
            if (model.Degree>= degreeSucess)
            {
                model.color = "green";
            }
            else
            {
                model.color = "red";
            }
 
            return View("Result",model);
        }


        public IActionResult GetAllTrainee(int crsId)
        {
            List<CrsREsult> crsREsults=db.CrsREsults.Where(n=>n.CourseId==crsId).ToList();
            Trainee trainee = new Trainee();
            Course course =new Course();
            List<TraineeDegreeViewModel> traineeDegreeViewModels=new List<TraineeDegreeViewModel>();
            TraineeDegreeViewModel traineeDegree =new TraineeDegreeViewModel();


            foreach (CrsREsult crs in crsREsults) 
            {
                trainee =db.Trainees.SingleOrDefault(n=>n.Id==crs.TraineeId);
                course =db.Courses.SingleOrDefault(n=>n.Id ==crs.CourseId);
                traineeDegree = new TraineeDegreeViewModel();
                traineeDegree.Id = trainee.Id;
                traineeDegree.Name = trainee.Name;
                traineeDegree.Address = trainee.Address;
                traineeDegree.ImageUrl= trainee.ImageUrl;
                traineeDegree.Course_Name = course.Name;
                traineeDegree.Degree = crs.Degree;
                if (crs.Degree >= course.MinDegree) 
                {
                    traineeDegree.color = "green";
                }
                else
                {
                    traineeDegree.color= "red";
                }
                traineeDegreeViewModels.Add(traineeDegree);
            }
            return View("GetAllTrainee",traineeDegreeViewModels);
        }

        public IActionResult GetAllCourse(int id)
        {
            List<CrsREsult> crsREsults = db.CrsREsults.Where(n => n.CourseId == id).ToList();
            Trainee trainee = new Trainee();
            Course course = new Course();
            List<TraineAllCoursesViewModel> traineeDegreeViewModels = new List<TraineAllCoursesViewModel>();
            TraineAllCoursesViewModel traineeDegree = new TraineAllCoursesViewModel();


            foreach (CrsREsult crs in crsREsults)
            {
                trainee = db.Trainees.SingleOrDefault(n => n.Id == crs.TraineeId);
                course = db.Courses.SingleOrDefault(n => n.Id == crs.CourseId);
                traineeDegree = new TraineAllCoursesViewModel();
                traineeDegree.Id = course.Id;
                traineeDegree.Name = course.Name;
                traineeDegree.MinDegree = course.MinDegree;
                traineeDegree.Degree = course.Degree;
                traineeDegree.TraineeName = trainee.Name;
                traineeDegree.Hours= course.Hours;
                traineeDegree.YourDegree = crs.Degree;
                if (crs.Degree >= course.MinDegree)
                {
                    traineeDegree.color = "green";
                }
                else
                {
                    traineeDegree.color = "red";
                }
                traineeDegreeViewModels.Add(traineeDegree);
            }
           
            return View("GetAllCourse",traineeDegreeViewModels);
        }
    }
}
