using BL;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_MicroscopicPicture
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        IRatingBL ratingBL;

        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingBL _ratingBL)
        { ratingBL = _ratingBL;

            Rating rating = (
                host: httpContext.Request.Host.Host,
   method: httpContext.Request.Method,
   path: httpContext.Request.Path,
   referer: httpContext.Request.Form
//user_agent:httpContext.Request.
);
            };

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
