using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFUI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			_carService = new CarManager(new EfCarDal());
			_colorService = new ColorManager(new EfColorDal());
			_brandService = new BrandManager(new EfBrandDal());
		}
		ICarService _carService;
		IColorService _colorService;
		IBrandService _brandService;
		//Car _selectCar;
		List<Car> cars;
		List<CarDetailDto> carsDto;
		private void Form1_Load(object sender, EventArgs e)
		{
			LoadCars();
			LoadBrand();
			LoadColor();
		}

		private void btAdd_Click(object sender, EventArgs e)
		{
			Car car = new Car
			{
				BrandID = Convert.ToInt32(cbBrandN.SelectedValue),
				ColorID = Convert.ToInt32(cbColorN.SelectedValue),
				DailyPrice = Convert.ToInt32(txPrice.Text),
				ModelYear = Convert.ToInt32(txYear.Text),
				Description = txDescription.Text
			};
			var result = _carService.Add(car);
			MessageBox.Show(Messages.CarAdded);
			LoadCars();
		}
		void LoadCars()
		{
			cars = _carService.GetCar().Data;
			carsDto = _carService.GetCarDetails().Data;
			dgCar.DataSource = carsDto;
			dgCarUpdate.DataSource = carsDto;
		}
		void LoadBrand()
		{
			List<Brand> brands = _brandService.GetAll().Data;
			cbBrand.DataSource = brands;
			cbBrand.DisplayMember = "BrandName";
			cbBrand.ValueMember = "BrandID";

			cbBrandN.DataSource = brands;
			cbBrandN.DisplayMember = "BrandName";
			cbBrandN.ValueMember = "BrandID";

			cbBrandU.DataSource = brands;
			cbBrandU.DisplayMember = "BrandName";
			cbBrandU.ValueMember = "BrandID";
		}
		void LoadColor()
		{
			List<Entities.Concrete.Color> colors = _colorService.GetAll().Data;
			cbColor.DataSource = colors;
			cbColor.DisplayMember = "ColorName";
			cbColor.ValueMember = "ColorID";

			cbColorN.DataSource = colors;
			cbColorN.DisplayMember = "ColorName";
			cbColorN.ValueMember = "ColorID";

			cbColorU.DataSource = colors;
			cbColorU.DisplayMember = "ColorName";
			cbColorU.ValueMember = "ColorID";
		}

		private void btClear_Click(object sender, EventArgs e)
		{
			LoadCars();
		}

		private void btAddColor_Click(object sender, EventArgs e)
		{
			Entities.Concrete.Color color = new Entities.Concrete.Color
			{
				ColorName = txColorName.Text
			};
			_colorService.Add(color);
		}

		private void btBrandAdd_Click(object sender, EventArgs e)
		{
			Brand brand = new Brand
			{
				BrandName = txBrandName.Text
			};
			_brandService.Add(brand);
		}

		private void dgCarUpdate_CellDoubleClick(object sender, EventArgs e)
		{
			cbBrandU.SelectedItem = dgCarUpdate.CurrentRow.Cells[1].Value.ToString();
			cbColorU.SelectedItem = dgCarUpdate.CurrentRow.Cells[2].Value.ToString();
			txYearU.Text = dgCarUpdate.CurrentRow.Cells[3].Value.ToString();
			txPriceU.Text = dgCarUpdate.CurrentRow.Cells[4].Value.ToString();
		}

		private void btUpdateC_Click(object sender, EventArgs e)
		{
			_carService.Update(new Car
			{
				BrandID = Convert.ToInt32(cbBrandU.SelectedItem),
				ColorID = Convert.ToInt32(cbColorU.SelectedItem),
				ModelYear = Convert.ToInt32(txYear.Text),
				DailyPrice = Convert.ToInt32(txPrice.Text),
				Description = txDescriptionU.Text
			});
			LoadCars();
		}
	}
}
