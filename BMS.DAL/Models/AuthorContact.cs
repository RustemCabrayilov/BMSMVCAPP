using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Models
{
    public class AuthorContact:BaseEntity
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
