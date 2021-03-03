using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarImagesController : ControllerBase
	{
		ICarImageService _carImageService;
		public CarImagesController(ICarImageService carImageService)
		{
			_carImageService = carImageService;
		}
		[HttpPost("Add")]
		public IActionResult Add([FromForm(Name =("Image"))] IFormFile file, [FromForm] CarImage image)
		{
			var result = _carImageService.Add(file, image);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpDelete("Delete")]
		public IActionResult Delete([FromForm(Name =("ImageID"))] int imageID)
		{
			var carImage = _carImageService.GetByID(imageID).Data;
			var result = _carImageService.Delete(carImage);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPut("Update")]
		public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("ImageID"))] int imageID)
		{
			var carImage = _carImageService.GetByID(imageID).Data;
			var result = _carImageService.Update(file, carImage);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetByID")]
		public IActionResult GetByID(int imageID)
		{
			var result = _carImageService.GetByID(imageID);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _carImageService.GetListImage();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("GetImagesByCarID")]
		public IActionResult GetAllByCarID(int carID)
		{
			var result = _carImageService.GetByID(carID);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
