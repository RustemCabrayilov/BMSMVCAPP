using BMS.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Data
{
	public class BMSDbContext : DbContext
	{
		public BMSDbContext(DbContextOptions<BMSDbContext> opts) : base(opts)
		{

		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<AuthorContact> AuthorContacts { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<BookCategory> BookCategory { get; set; }
	}
}
