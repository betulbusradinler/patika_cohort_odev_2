using System.ComponentModel.DataAnnotations;

namespace PatikaCohortsOdev2.Configurations.Extensions;
public class ValidatorResponse
{
    public bool IsValid { get; set; }
    public string? Result { get; set; }
}
public static class ValidationResult
{
    // Validation işlemler için her logic de aynı hata kodlarını tekrar yazmamak için (DRY) static bir method oluşturuldu.
    public static ValidatorResponse RequestModelErros(this ValidationAttribute validationResult)
    {
        ValidatorResponse validResponse = new();

        if (validationResult.ErrorMessage != null)
        {
            validResponse.IsValid = false;
            validResponse.Result = validationResult.ErrorMessage;

            return validResponse;
        }

        validResponse.Result = null;
        validResponse.IsValid = true;
        return validResponse;

    }
}
