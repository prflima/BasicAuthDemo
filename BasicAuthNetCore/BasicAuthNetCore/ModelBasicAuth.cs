using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthNetCore
{
	public class ModelBasicAuth
	{
		public ModelBasicAuth()
		{
			Username = "Paulo";
			Password = "BasicAuthTest";
		}

		public string Username { get; set; }
		public string Password { get; set; }
	}
}
