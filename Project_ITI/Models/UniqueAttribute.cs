using System.ComponentModel.DataAnnotations;

namespace Project_ITI.Models
{
    public class UniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();
            ITIContext db = new ITIContext();
            Course course = db.Courses.FirstOrDefault(c => c.Name == name);
            if (course == null)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("the cours is alredy Found");
        }
    }
}
