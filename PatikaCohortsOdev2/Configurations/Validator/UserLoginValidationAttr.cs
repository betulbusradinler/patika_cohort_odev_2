using Microsoft.AspNetCore.Mvc.Filters;
using PatikaCohortsOdev2.Model;
using System.ComponentModel.DataAnnotations;

namespace PatikaCohortsOdev2.Configurations.Validator;

// Use Custom Attribute

public class UserLoginValidationAttr : ValidationAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var result = context.HttpContext.Request.Body.ToString;
        var r1 = context.HttpContext.Request.Body.Position;
        var r2 = context.HttpContext.Request.Body.GetType;
        var r3 = context.HttpContext.Request.Body.GetType;
        throw new NotImplementedException();
    }

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
