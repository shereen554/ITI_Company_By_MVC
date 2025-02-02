namespace Project_ITI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        // nav one to many
        public virtual List<Instractor> Instractors { get; }=new List<Instractor>();

        public virtual List<Course>Courses { get; }=new List<Course>();

        public virtual List<Trainee> Trainees { get; } =new List<Trainee>();
    }
}
