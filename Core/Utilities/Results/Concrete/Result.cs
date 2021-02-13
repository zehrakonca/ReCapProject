using Core.Utilities.Results.Abstact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
	public class Result : IResult
	{
		public Result(bool success, string message) : this(success)
		{
			success = Success;
			message = Message;
		}
		public Result(bool success)
		{
			success = Success;
		}
		public bool Success { get; }

		public string Message { get; }
	}
}
