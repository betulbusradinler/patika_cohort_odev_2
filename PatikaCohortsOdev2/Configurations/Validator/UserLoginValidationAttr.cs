using PatikaCohortsOdev2.Model;
using System.ComponentModel.DataAnnotations;

namespace PatikaCohortsOdev2.Configurations.Validator;

// Use Custom Attribute

public class UserLoginValidationAttr : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var user = (User)validationContext.ObjectInstance;

        if (user.Email == "patika.test.api@gmail.com")
        {
            return ValidationResult.Success;
        }

        if (user.Password == "Sifredogru.34")
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Mail veya Şifre Hatalı");
    }
}
