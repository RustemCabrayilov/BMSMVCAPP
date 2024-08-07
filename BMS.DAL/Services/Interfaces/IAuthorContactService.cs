using BMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorContactDto = BMS.DAL.Dtos.AuthorContactDto;

namespace BMS.DAL.Services.Interfaces
{
    public interface IAuthorContactService
    {
        public Task<AuthorContactDto> Add(AuthorContactDto dto);
        public Task<List<AuthorContact>> GetAll(params string[] includes);
		public Task<AuthorContact> Get(int id);
        public AuthorContact Delete(int id);
        public Task<AuthorContact> Edit(AuthorContactDto dto,int id);
	}
}
