using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ServiceModels.User
{
    public class UpdateUserModel : UserModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
