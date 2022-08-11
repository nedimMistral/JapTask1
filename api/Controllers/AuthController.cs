using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;
using api.Service.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authSvc;

        public AuthController(IAuthService authSvc)
        {
            _authSvc = authSvc;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto req)
        {
            var res = await _authSvc.Register(
                new User { Username = req.Username }, req.Password
            );
            if(!res.Success) {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto req)
        {
            var res = await _authSvc.Login(req.Username, req.Password);
            if(!res.Success) {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}