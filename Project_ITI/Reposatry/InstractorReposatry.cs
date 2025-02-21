using Project_ITI.Models;

namespace Project_ITI.Reposatry
{
    public class InstractorReposatry : IInstractorReposatry
    {
        ITIContext db;
        public InstractorReposatry(ITIContext db)
        {
            this.db = db;
        }
        public void Add(Instractor instractor)
        {
           db.Instractors.Add(instractor);
        }

        public int Delete(int id)
        {
           Instractor instractor=db.Instractors.FirstOrDefault(n=>n.Id==id);
            if (instractor != null)
            {
                db.Instractors.Remove(instractor);
                return 1;
            }
            return 0;

        }

        public List<Instractor> GetAll()
        {
            return db.Instractors.ToList();
        }

        public Instractor GetById(int id)
        {
            return db.Instractors.FirstOrDefault(n => n.Id == id);
        }

        public int SaveChange()
        {
           return db.SaveChanges();
        }

        public List<Instractor> Search(string name)
        {
            return db.Instractors.Where(n => n.Name == name).ToList();
        }
        public void Update(Instractor instractor)
        {
           db.Instractors.Update(instractor);
        }
    }
}
