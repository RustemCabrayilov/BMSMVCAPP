using BMS.DAL.AutoMappers;
using BMS.DAL.Data;
using BMS.DAL.Repository;
using BMS.DAL.Services.Implementations;
using BMS.DAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BMS.WEBUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddAutoMapper(typeof(BookProfile));
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<BMSDbContext>(opts =>
			{
				opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString"));

			});
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
			builder.Services.AddScoped(typeof(IBookService), typeof(BookService));
			builder.Services.AddScoped(typeof(IAuthorService), typeof(AuthorService));
			builder.Services.AddScoped(typeof(IAuthorContactService), typeof(AuthorContactService));
			builder.Services.AddScoped(typeof(IPublisherService), typeof(PublisherService));
			builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
			builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
