﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IColorService
	{
		List<Color> GetAll();
		Color GetById(int colorID);
		void Add(Color color);
		void Update(Color color);
		void Delete(Color color);
	}
}
