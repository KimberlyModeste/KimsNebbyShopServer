using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KimsNebbyShopServer.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }  = string.Empty;
        public string Username { get; set; }  = string.Empty;
        public string Password { get; set; }  = string.Empty;
        // public long Salt { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }  = string.Empty;
        public string CardNumber { get; set; } = string.Empty;

    }
}