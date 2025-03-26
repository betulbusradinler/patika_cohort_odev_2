using System.ComponentModel.DataAnnotations;

namespace PatikaCohortsOdev2.Model;

public class Customer
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 10 characters")]
    public string Name { get; set; }
    [Required]
    [StringLength(maximumLength: 10, MinimumLength = 3, ErrorMessage = "Surname must be between 3 and 10 characters")]
    public string Surname { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address. Please enter a valid email address")]
    public string Email { get; set; }
    [Required]
    [Phone(ErrorMessage = "Invalid Phone Number. Please enter a valid phone number")]
    public string PhoneNumber { get; set; }
   
    [Required]
    //[CustomerAgeAttribute]
    public DateTime DateOfBirth { get; set; }
}
