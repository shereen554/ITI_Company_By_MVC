using Project_ITI.Models;

namespace Project_ITI.Reposatry
{
    public class CourseReposatry : ICourseReposatry
    {
        ITIContext db;
        public CourseReposatry(ITIContext db)
        {
            this.db = db;
        }

        public void Add(Course course)
        {
            db.Add(course);
        }

        public void Delete(Course course)
        {
            db.Courses.Remove(course);
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(n => n.Id == id);
        }

        public Course GetByName(string name)
        {
            return db.Courses.FirstOrDefault(n => n.Name == name);
        }

        public int SaveChange()
        {
            return db.SaveChanges();
        }

        public void Update(Course course)
        {
           db.Courses.Update(course);
        }
    }
}
