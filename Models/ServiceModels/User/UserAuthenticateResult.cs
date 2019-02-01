using System;
using System.Collections.Generic;
using System.Text;
using static Models.Enums.ResultEnum;

namespace Models.ServiceModels.User
{
    public class UserAuthenticateResult
    {
        public UserDto User { get; set; }
        public ServiceResult Result { get; set; }
    }
}
