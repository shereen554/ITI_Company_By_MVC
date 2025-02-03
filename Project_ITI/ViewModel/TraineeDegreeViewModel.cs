using Project_ITI.Models;

namespace Project_ITI.ViewModel
{
    public class TraineeDegreeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public decimal Degree { get; set; }
        public string color { get; set; }   

        public string Course_Name { get; set; }
    }
}
