using BMS.DAL.Models;
using BMS.DAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WEBUI.Controllers
{
	public class PublishersController : Controller
	{
		private readonly IGenericService<Publisher> _publisherService;
        public PublishersController(IGenericService<Publisher> publisherService)
        {
            _publisherService = publisherService;
        }
        public async Task<IActionResult> Index()
		{
			var publishers = await _publisherService.GetAll();
			if (publishers.Any())
			{
				ViewBag.HasData = true;
			}
			else
			{
				ViewBag.HasData = false;
				ViewData["Message"] = "No publishers here";

			}
			return View(publishers);
		}
	}
}
