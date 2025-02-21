using Project_ITI.Models;

namespace Project_ITI.Reposatry
{
    public interface IDepartmentReposatry
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Update(Department course);
        void Add(Department department);
        string GetDepartmentName (int id);
        void Delete(Department course);
        int SaveChange();
    }
}