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

namespace BMS.DAL.Services.Implementations
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
            return _bookRepository.GetAll().Result.
                Include(x => x.Publisher)
                .Include(x => x.Author)
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category);
        }
        /*
                public T Delete(int id)
                {

                    return entity;
                }

                public async Task<T> Get(int id)
                {
                    return entity;
                }


                public T Update(T entity)
                {
                    return entity;
                }*/
    }
}
