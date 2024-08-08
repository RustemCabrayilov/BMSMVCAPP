using BMS.DAL.Dtos;
using BMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Services.Interfaces
{
	public interface IPublisherService
	{
		public Task<PublisherDto> Add(PublisherDto dto);
		public Task<Publisher> Update(PublisherDto dto,int id);
		public Publisher Delete(int id);
		public Task<Publisher> Get(int id,params string[] includes);
		public Task<IQueryable<Publisher>> GetAll(params string[] includes);
	}
}
