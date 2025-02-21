using Project_ITI.Models;

namespace Project_ITI.Reposatry
{
    public interface IInstractorReposatry
    {
        List<Instractor> GetAll();
        Instractor GetById(int id);
        void Update(Instractor instractor);
        int Delete(int id);

        List<Instractor> Search(string name);
        void Add(Instractor instractor);
        int SaveChange();
    }
}
