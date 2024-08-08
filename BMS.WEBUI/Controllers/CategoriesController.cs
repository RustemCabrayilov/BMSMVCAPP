using BMS.DAL.Models;
using BMS.DAL.Services.Interfaces;
using BMS.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace BMS.WEBUI.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
			_categoryService = categoryService;   
        }
        public async Task<IActionResult> Index()
		{
			var categories =  _categoryService.GetAll("BookCategories.Book").Result.ToList();
		var model =	categories.Select(x => new CategoryViewModel
			{
				Id = x.Id,
				Name = x.Name,
			});
			if (categories.Any())
			{
				ViewBag.HasData = true;
			}
			else
			{
				ViewBag.HasData = false;
				ViewData["Message"] = "No books here";
			}
			return View(model.ToList());
		}
	}
}
