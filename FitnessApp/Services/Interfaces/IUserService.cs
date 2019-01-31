using Models.DtoModels;
using Models.ServiceModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Models.Enums.ResultEnum;

namespace FitnessApp.Services.Interfaces
{
    public interface IUserService
    {
        UserAuthenticateResult Authenticate(string username, string password);
        ServiceResult AddUser(AddUserModel user);
        ServiceResult UpdateUser(UpdateUserModel userParam);
        ServiceResult DeleteUser(int id);
    }
}
