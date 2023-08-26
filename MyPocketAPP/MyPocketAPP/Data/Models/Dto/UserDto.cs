using System;
using System.Collections.Generic;
using System.Text;

namespace MyPocketAPP.Data.Models.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
    }
}
