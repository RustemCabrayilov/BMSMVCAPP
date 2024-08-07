using BMS.DAL.Dtos;
using BMS.DAL.Models;
using BMS.DAL.Repository;
using BMS.DAL.Services.Interfaces;
using BMS.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BMS.WEBUI.Controllers
{
	public class AuthorsController : Controller
	{

		private readonly IAuthorService _authorService;
		private readonly IAuthorContactService _authorContactService;
		public AuthorsController(IAuthorService authorService, IAuthorContactService authorContactService)
		{
			_authorService = authorService;
			_authorContactService = authorContactService;
		}
		public async Task<IActionResult> Index()
		{
			var authors = await _authorService.GetAll();

			if (authors.Any())
			{
				ViewBag.HasData = true;
			
			}
			else
			{
				ViewBag.HasData = false;
				ViewData["Message"] = "No authors here";

			}
			return View(authors);
		}
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(AuthorDto dto)
		{
			await _authorService.Add(dto);
			return RedirectToAction("Index");
		}
	}
}
