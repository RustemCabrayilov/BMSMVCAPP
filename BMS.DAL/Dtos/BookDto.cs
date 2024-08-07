using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS.DAL.Models;

namespace BMS.DAL.Dtos
{
    public class BookDto 
    {
        public string Name { get; set; }
        public List<int> CategoryIds { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
