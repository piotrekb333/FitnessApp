using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Configuration;
using FitnessApp.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.DtoModels;
using Models.Entities;
using Models.ServiceModels.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Models.Enums.ResultEnum;

namespace FitnessApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings, IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public UserAuthenticateResult Authenticate(string username, string password)
        {
            UserAuthenticateResult result = new UserAuthenticateResult();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                result.Result = Models.Enums.ResultEnum.ServiceResult.BadRequest;
                return result;
            }
            var user = _userRepository.GetOneByCondition(x => x.Username == username);

            if (user == null)
            {
                result.Result = Models.Enums.ResultEnum.ServiceResult.NotFound;
                return result;
            }

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                result.Result = Models.Enums.ResultEnum.ServiceResult.BadRequest;
                return result;
            }

            // authentication successful
            var userDto = _mapper.Map<UserDto>(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            userDto.Token = tokenString;
            result.User = userDto;
            result.Result = Models.Enums.ResultEnum.ServiceResult.Ok;
            return result;
        }

        public ServiceResult AddUser(AddUserModel user)
        {
            User userModel = _mapper.Map<User>(user);
            if (_userRepository.GetByCondition(x => x.Username == user.Username) != null)
            {
                return ServiceResult.Exists;
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            userModel.PasswordHash = passwordHash;
            userModel.PasswordSalt = passwordSalt;

            _userRepository.Create(userModel);
            _userRepository.Save();

            return ServiceResult.Ok;
        }

        public ServiceResult UpdateUser(UpdateUserModel userParam)
        {
            var user = _userRepository.GetById(userParam.Id);

            if (user == null)
                return ServiceResult.NotFound;

            if (userParam.Username != user.Username)
            {
                if (_userRepository.GetOneByCondition(x => x.Username == userParam.Username) != null)
                    return ServiceResult.NotFound;
            }
            User userModel = _mapper.Map<UpdateUserModel, User>(userParam, user);

            if (!string.IsNullOrWhiteSpace(userParam.Password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(userParam.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userRepository.Update(userModel);
            _userRepository.Save();
            return ServiceResult.Ok;
        }

        public ServiceResult DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                return ServiceResult.NotFound;
            _userRepository.Delete(user);
            _userRepository.Save();
            return ServiceResult.Ok;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
