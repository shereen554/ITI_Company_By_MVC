using Project_ITI.Reposatry;
using System.ComponentModel.DataAnnotations;

namespace Project_ITI.Models
{
    public class UniqueAttribute: ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();
            ITIContext db = new ITIContext();

            var coursereposatry=(ICourseReposatry)validationContext.GetService(typeof(ICourseReposatry));
            Course course = coursereposatry.GetByName(name);
            if (course == null)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("the cours is alredy Found");
        }
    }
}
