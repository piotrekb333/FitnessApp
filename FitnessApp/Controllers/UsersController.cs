using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Configuration;
using FitnessApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ServiceModels.User;
using static Models.Enums.ResultEnum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public UsersController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var result = _userService.GetUser(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(AddUserModel model)
        {
            var result = _userService.AddUser(model);
            if (result == ServiceResult.Ok)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(UpdateUserModel model)
        {
            var result = _userService.UpdateUser(model);
            if (result == ServiceResult.Ok)
                return Ok();
            else if (result == ServiceResult.NotFound)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result == ServiceResult.Ok)
                return Ok();
            else if (result == ServiceResult.NotFound)
                return NoContent();
            else
                return BadRequest();
        }
    }
}
