using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Dtos
{
    public class AuthorContactDto
    {
        public int AuthorId { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
