﻿using Microsoft.AspNetCore.Diagnostics;

namespace PatikaCohortsOdev2.MiddleWare
{
    public class UseGlobalException(ILogger<UseGlobalException> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            string errorMessage = $"Bir hata oluştu. Hata mesajı :  {exception.Message}";
            logger.LogError(exception, errorMessage);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new
            {
                Title = "Server Error",
                Status = httpContext.Response.StatusCode,
                Message = errorMessage
            });

            return true;
        }
    }
}