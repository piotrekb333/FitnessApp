using Models.DtoModels;
using Models.ServiceModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Interfaces
{
    public interface IUserService
    {
        UserAuthenticateResult Authenticate(string username, string password);
    }
}
