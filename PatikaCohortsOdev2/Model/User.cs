using PatikaCohortsOdev2.Configurations.Validator;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatikaCohortsOdev2.Model;

[UserLoginValidationAttr]
public class User
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address. Please enter a valid email address")]
    public string Email { get; set; }

    [Required]
    [PasswordPropertyText(true)]
    public string Password { get; set; }
}
