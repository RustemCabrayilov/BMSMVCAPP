using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BookCategory> BookCategories { get; set;}
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set;}
    }
}
