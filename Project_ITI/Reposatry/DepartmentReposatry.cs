using Project_ITI.Models;

namespace Project_ITI.Reposatry
{
    public class DepartmentReposatry : IDepartmentReposatry
    {
        ITIContext db;
        public DepartmentReposatry(ITIContext db) //Inject ask
        {
                this.db = db;
        }

        public void Add(Department department)
        {
           db.Add(department);
        }

        public void Delete(Department Dept)
        {
           db.Departments.Remove(Dept);
        }

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(n => n.Id == id);
        }

        public string GetDepartmentName(int id)
        {
            return db.Departments.FirstOrDefault(n => n.Id == id).Name;
        }

        public int SaveChange()
        {
           return db.SaveChanges();
        }

        public void Update(Department Dept)
        {
            db.Departments.Update(Dept);
        }
    }
}
