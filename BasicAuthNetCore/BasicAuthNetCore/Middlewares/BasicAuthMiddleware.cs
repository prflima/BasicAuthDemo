using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BasicAuthNetCore.Middlewares
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class BasicAuthMiddleware
	{
		private readonly RequestDelegate _next;
		private ModelBasicAuth modelBasicAuth = new ModelBasicAuth();

		public BasicAuthMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			string authHeader = httpContext.Request.Headers["Authorization"];
			if (authHeader != null && authHeader.StartsWith("Basic"))
			{
				string encodeUsernameAndPassword = authHeader.Substring("Basic".Length).Trim();
				Encoding encoding = Encoding.GetEncoding("UTF-8");
				string[] usernameAndPassword = encoding.GetString(Convert.FromBase64String(encodeUsernameAndPassword)).Split(":");

				string username = usernameAndPassword[0];
				string password = usernameAndPassword[1];

				if (username == modelBasicAuth.Username && password == modelBasicAuth.Password)
				{
					await _next.Invoke(httpContext);
				}
				else
				{
					httpContext.Response.StatusCode = 401;
					return;
				}
			}
			else
			{
				httpContext.Response.StatusCode = 401;
				return;
			}
		}
	}

	// Extension method used to add the middleware to the HTTP request pipeline.
	public static class BasicAuthMiddlewareExtensions
	{
		public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<BasicAuthMiddleware>();
		}
	}
}
