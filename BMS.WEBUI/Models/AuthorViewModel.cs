﻿using BMS.DAL.Models;

namespace BMS.WEBUI.Models
{
	public class AuthorViewModel
	{
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
