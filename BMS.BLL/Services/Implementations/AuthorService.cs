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

namespace BMS.BLL.Services.Implementations
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

		public async Task<IQueryable<Author>> GetAll(params string[] includes)
		{
			return await _authorRepository.GetAll(includes);
		}public async Task<Author> Get(int id)
		{
			return await _authorRepository.Get(id);
		}

		public async Task<Author> Update(AuthorDto dto, int id)
		{
			var author = await Get(id);
			author.Name = dto.Name;
			author.Surname = dto.Surname;
			return  _authorRepository.Update(author);
		}

		public  Author Delete(int id)
		{
			
			return  _authorRepository.Delete(id); ;
		}
	}
}
