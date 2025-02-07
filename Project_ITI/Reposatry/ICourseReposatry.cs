using Project_ITI.Models;

namespace Project_ITI.Reposatry
{
    public interface ICourseReposatry
    {
        List<Course> GetAll();
        Course GetById(int id);
        Course GetByName(string name);
        void Update(Course course);
        void Delete(Course course);
        void Add (Course course);
        int SaveChange();
    }
}