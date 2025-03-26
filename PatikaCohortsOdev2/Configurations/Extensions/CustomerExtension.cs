using PatikaCohortsOdev2.Configurations.Response;
using PatikaCohortsOdev2.Model;

namespace PatikaCohortsOdev2.Configurations.Extensions;

public static class CustomerExtension
{
    public static CommandResponse IsNull(this Customer customer)
    {
        CommandResponse response = new();

        if (customer == null)
        {
            response.Status = false;
            response.Message = " Customer was not found ";
            return response;
        }

        response.Status = true;
        response.Message = " Cutomer is not null ";
        return response;

    }
    public static CommandResponse IsNull(this List<Customer> customers)
    {
        CommandResponse response = new();

        if (customers == null)
        {
            response.Status = false;
            response.Message = " Customers was not found ";
            return response;
        }

        response.Status = true;
        response.Message = " Cutomers is not null ";
        return response;

    }
}
