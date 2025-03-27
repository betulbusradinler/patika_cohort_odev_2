using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace PatikaCohortsOdev2.MiddleWare;

// Global Loglama yapan ve exception middleware.
public class GlobalExceptionLogMiddleware
{
    private readonly RequestDelegate _next;
    public GlobalExceptionLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        try
        {
            string message = " [Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
            Console.WriteLine(message);

            await _next(context);
            watch.Stop();

            message = " [Response] " + context.Request.Method + " - "
                + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed + "ms";
            Console.WriteLine(message);

        }
        catch (Exception ex)
        {
            watch.Stop();
            await HandleException(context, ex, watch);
        }
    }

    private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
    {
        string message = " [Error]  HTTP " + context.Request.Method + " - " + context.Response.StatusCode
            + " ErrorMessage " + ex.Message + " in " + watch.Elapsed.TotalMicroseconds + " ms ";
        Console.WriteLine(message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
        return context.Response.WriteAsync(result);
    }
}

public static class GlobalLogMiddlewareExtension
{
    public static IApplicationBuilder UseGlobalLogMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionLogMiddleware>();
    }
}
