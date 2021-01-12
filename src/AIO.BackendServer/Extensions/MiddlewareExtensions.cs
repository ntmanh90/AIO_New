using AIO.BackendServer.Helpers;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIO.BackendServer.Extensions
{
    public static class MiddlewareExtensions
    {
        //Xây dựng Extensions chạy Middleware thông qua IApplicationBuilder
        // phần này sẽ được thiết lập chạy trong start
        public static IApplicationBuilder UseErrorWrapping(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}