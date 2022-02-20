using BL;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace project_MicroscopicPicture
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        IRatingBL ratingBL;

        private readonly RequestDelegate _next;
       

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingBL _ratingBL, ILogger<RatingMiddleware> logger)
        { ratingBL = _ratingBL;

            Rating rating = new Rating {
                Host = httpContext.Request.Host.Host,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path.Value,
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                Referer = httpContext.Request.Headers["Referrer"],
                RecordDate = DateTime.Now
            };
          await  ratingBL.Post(rating);
          await  _next(httpContext);
             
           

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
