using AutoMapper;
using BMS.DAL.Dtos;
using BMS.DAL.Models;
using BMS.DAL.Repository;
using BMS.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Services.Implementations
{
	public class PublisherService : IPublisherService
	{
		private readonly IMapper _mapper;
		private readonly IGenericRepository<Publisher> _publisherRepository;
		public PublisherService(IMapper mapper,
			IGenericRepository<Publisher> publisherRepository)
		{
			_mapper = mapper;
			_publisherRepository = publisherRepository;
		}
		public async Task<PublisherDto> Add(PublisherDto dto)
		{
			Publisher publisher = _mapper.Map<Publisher>(dto);
			await _publisherRepository.Add(publisher);
			await _publisherRepository.SaveAsync();
			return dto;
		}

		public Publisher Delete(int id)
		{
			return _publisherRepository.Delete(id);
		}

		public async  Task<Publisher> Get(int id,params string[] includes)
		{
			return await _publisherRepository.Get(id, includes);
		}

		public async Task<IQueryable<Publisher>> GetAll(params string[] includes)
		{
			return await _publisherRepository.GetAll(includes);
		}

		public async Task<Publisher> Update(PublisherDto dto,int id)
		{
			var publisher = await Get(id);
			publisher.Name = dto.Name;
			return _publisherRepository.Update(publisher); ;
		}
	}
}
