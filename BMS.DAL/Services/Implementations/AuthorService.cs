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
	public class AuthorService : IAuthorService
	{

		private readonly IMapper _mapper;
		private IGenericRepository<Author> _authorRepository;
		public AuthorService(IMapper mapper,
			IGenericRepository<Author> authorRepository)
		{
			_mapper = mapper;
			_authorRepository = authorRepository;
		}
		public async Task<AuthorDto> Add(AuthorDto dto)
		{
			Author author = _mapper.Map<Author>(dto);
			await _authorRepository.Add(author);
			await _authorRepository.SaveAsync();
			return dto;
		}

		public async Task<List<Author>> GetAll(params string[] includes)
		{
			return  _authorRepository.GetAll().Result.ToList();
		}public async Task<Author> Get(int id)
		{
			return await _authorRepository.Get(id);
		}
	}
}
