using AutoMapper;
using BMS.DAL.Dtos;
using BMS.DAL.Models;
using BMS.DAL.Repository;
using BMS.DAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BMS.BLL.Services.Implementations
{
	public class BookService : IBookService
	{
		private readonly IGenericRepository<Book> _bookRepository;
		private readonly IGenericRepository<BookCategory> _bookCategoryRepository;
		private readonly IMapper _mapper;
		public BookService(IGenericRepository<Book> bookRepository,
			IGenericRepository<BookCategory> bookCategoryRepository,
			IMapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
			_bookCategoryRepository = bookCategoryRepository;
		}
		public async Task<BookDto> Add(BookDto dto)
		{
			Book book = _mapper.Map<Book>(dto);
			foreach (var item in dto.CategoryIds)
			{
				BookCategory category = new BookCategory
				{
					Book = book,
					CategoryId = item
				};
				await _bookCategoryRepository.Add(category);
				book.BookCategories.Add(category);
			}
			await _bookRepository.Add(book);
			await _bookRepository.SaveAsync();
			return dto;
		}
		public async Task<IQueryable<Book>> GetAll(params string[] includes)
		{
			return await _bookRepository.GetAll(includes);
			/*	Result.
				Include(x => x.Publisher)
				.Include(x => x.Author)
				.Include(x => x.BookCategories)
				.ThenInclude(x => x.Category);*/
		}

		public Book Delete(int id)
		{
			var entity = _bookRepository.Delete(id);
			return entity;
		}

		public async Task<Book> Get(int id,params string[] includes)
		{
			return await _bookRepository.Get(id,includes);

            
        }


		public async Task<Book> Update(BookDto dto, int id)
		{
			var book = await Get(id);
			book.AuthorId = dto.AuthorId;
			book.PublisherId = dto.PublisherId;
			book.Name = dto.Name;
			List<BookCategory> removableCategory =  _bookCategoryRepository.GetAll().Result.Where(x=>x.BookId==book.Id).ToList();
            foreach (var item in removableCategory)
            {
            _bookCategoryRepository.Delete(item.Id);
                
            }
			foreach (var categoryId in dto.CategoryIds)
			{
				
				BookCategory bookCategory = new BookCategory()
				{
					Book = book,
					CategoryId = categoryId,
				};
				
			   await _bookCategoryRepository.Add(bookCategory);
				book.BookCategories.Add(bookCategory);
			}	
			return _bookRepository.Update(book); ;

		}
	}
}
