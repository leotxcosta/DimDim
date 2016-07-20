using DimDim.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.Web.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			var vm = new HomeViewModel();
			//vm.Title = "Dim Dim";
			vm.Now = DateTimeOffset.Now;

			return View(vm);

		}
	}
}
