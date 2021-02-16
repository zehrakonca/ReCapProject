using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		ICarService _carService;
		public CarsController(ICarService carService)
		{
			_carService = carService;
		}
		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _carService.GetCar();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("GetByID")]
		public IActionResult GetByID(int carID)
		{
			var result = _carService.GetByID(carID);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("Add")]
		public IActionResult Add(Car car)
		{
			var result = _carService.Add(car);
			if(result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("Delete")]
		public IActionResult Delete(Car car)
		{
			var result = _carService.Delete(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("Update")]
		public IActionResult Update(Car car)
		{
			var result = _carService.Update(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
