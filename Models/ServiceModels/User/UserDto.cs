using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ServiceModels.User
{
    public class UserDto : UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
