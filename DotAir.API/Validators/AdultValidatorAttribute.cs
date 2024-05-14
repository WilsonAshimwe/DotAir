using System.ComponentModel.DataAnnotations;

namespace DotAir.API.Validators
{
    public class AdultValidatorAttribute : ValidationAttribute
    {

        public override bool IsValid(object? value)
        {
            if (value is null)
            {
                return true;
            }
            if(value is DateTime date)
            {
                int age = DateTime.Now.Year - date.Year;
                if(DateTime.Now.DayOfYear > date.DayOfYear)
                {
                    age--;
                }
                return age >= 18;
            }
            return false;
        }
    }
}
