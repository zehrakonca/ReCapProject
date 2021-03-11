using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
	public class CarImagesOperationDto :IDto
	{
		public int Id { get; set; }
		public int CarId { get; set; }
		public List<IFormFile> Images { get; set; }
	}
}
