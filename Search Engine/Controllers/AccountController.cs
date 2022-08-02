using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchEngine.BusinessLogic.Services.Interfaces;
using SearchEngine.Common.DTOs;
using SearchEngine.Model;
using SearchEngine.Model.DatabaseModels;
using System.Security.Cryptography;
using System.Text;

namespace Search_Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult<BrowserDto> Register(RegisterDto registerDto)
        {
            return Ok(_accountService.Register(registerDto));
        }

        [HttpPost("login")]
        public ActionResult<BrowserDto> Register(LoginDto loginDto)
        {
            return Ok(_accountService.Login(loginDto));
        }
    }
}
