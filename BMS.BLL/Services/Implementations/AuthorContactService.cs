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
using AuthorContactDto = BMS.DAL.Dtos.AuthorContactDto;

namespace BMS.BLL.Services.Implementations
{
	public class AuthorContactService : IAuthorContactService
	{
		private readonly IMapper _mapper;
		private readonly IGenericRepository<AuthorContact> _authorContactRepository;
        
        public AuthorContactService(IMapper mapper, IGenericRepository<AuthorContact> authorContactRepository)
		{
			_mapper = mapper;
			_authorContactRepository = authorContactRepository;
		}
		public async Task<AuthorContactDto> Add(AuthorContactDto dto)
		{
			AuthorContact authorContact = _mapper.Map<AuthorContact>(dto);
			await _authorContactRepository.Add(authorContact);
			await _authorContactRepository.SaveAsync();
			return dto;
		}

		public async Task<List<AuthorContact>> GetAll(params string[] includes)
		{
			var authors=await _authorContactRepository.GetAll();

			return authors.ToList();
		}
		public async Task<AuthorContact> Get(int id,params string[] includes)
		{
			return await _authorContactRepository.Get(id,includes);

		}public AuthorContact  Delete(int id)
		{
			return  _authorContactRepository.Delete(id);
		}

        public  async Task<AuthorContact> Update(AuthorContactDto dto,int id)
        {

			var authorContact = await Get(id);
			authorContact.ContactNumber = dto.ContactNumber;
			authorContact.Address = dto.Address;
			authorContact.AuthorId = dto.AuthorId;
            return _authorContactRepository.Update(authorContact); ;
        }
    }
}
