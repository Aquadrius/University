
using Microsoft.AspNetCore.Mvc;
using University.Models;
using System.Net;
using University.DAL.Repositories.Interfaces;
using University.Dto;


namespace University.Controllers.UserController
{
    [Route("api/UserAuth")]
    [ApiController]
    public class UserController:Controller

    {
        private readonly IUserRepository _userRepo;
        public ApiResponse _response;

        public UserController (IUserRepository userRepo)
        {
            _userRepo = userRepo;
            this._response = new();
        }
        [HttpPost("login")]
        public async Task <IActionResult> Login([FromBody] Dto.LoginRequest model)

        {
            var LoginResponse = await _userRepo.Login(model);

            if (LoginResponse.User == null || string.IsNullOrEmpty(LoginResponse.Token))

            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(LoginResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest model)

        {
            bool ifUserNameUnique = _userRepo.IsUiqueUser(model.UserName);

            if(!ifUserNameUnique) 

            { 

            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            return BadRequest(new { message = "Username alredy exists" }); 
                
            }
            var user = await _userRepo.Register(model);
            if (user != null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(new { message = "Error while registering" });

            }
             _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok();
    }
  }

}
