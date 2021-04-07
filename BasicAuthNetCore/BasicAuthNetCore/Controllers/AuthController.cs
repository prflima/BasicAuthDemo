using Microsoft.AspNetCore.Mvc;
using System;

namespace BasicAuthNetCore.Controllers
{
	[Route("api/auth")]
	public class AuthController : Controller
	{
		[Produces("text/plain")]
		[Route("FirstDemo")]
		public IActionResult FirstAuth()
		{
			try
			{
				return Ok("First authentication is ok!");
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[Produces("text/html")]
		[Route("SecondDemo")]
		public IActionResult SecondAuth()
		{
			try
			{
				return new ContentResult()
				{
					ContentType = "text/html",
					Content = "<b><i>Second authentication is ok!</i></b>",
				};
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
	}
}
