using Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Interfaces
{
    public interface IUserService
    {
        UserDto Authenticate(string username, string password);
    }
}
