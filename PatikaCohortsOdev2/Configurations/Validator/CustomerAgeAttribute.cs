using PatikaCohortsOdev2.Model;
using System.ComponentModel.DataAnnotations;

namespace PatikaCohortsOdev2.Configurations.Validator;

public class CustomerAgeAttribute
{
    //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    //{
    //    var customer = (Customer)validationContext.ObjectInstance;
    //    if (customer.DateOfBirth == DateTime.MinValue)
    //    {
    //        return new ValidationResult("Date of Birth is required");
    //    }
    //    var age = DateTime.Today.Year - customer.DateOfBirth.Year;
    //    if (age < 18 || age > 60)
    //    {
    //        return new ValidationResult("Age must be between 18 and 60");
    //    }
    //    if (customer.DateOfBirth >= DateTime.Today)
    //    {
    //        return new ValidationResult("Date of Birth can not be greater than today");
    //    }
    //    return ValidationResult.Success;
    //}
}
