using SearchEngine.Model;
using SearchEngine.BusinessLogic.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using SearchEngine.Common.DTOs;
using SearchEngine.Model.DatabaseModels;

namespace CarDealerships.BusinessLogic.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly BrowserContext _db;
        private readonly ITokenService _tokenService;
        public AccountService(BrowserContext db, ITokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        public BrowserDto Login(LoginDto loginDto)
        {
            var browser = _db.Browsers.SingleOrDefault(u => u.Login == loginDto.Login);
            if (browser == null)
            {
                throw new Exception("Incorrect login");
            }
            var hmac = new HMACSHA512(browser.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != browser.PasswordHash[i])
                {
                    throw new Exception("Incorrect password");
                }
            }
            return new BrowserDto { Login = browser.Login, Token = _tokenService.CreateToken(browser) };
        }
        public BrowserDto Register(RegisterDto registerDto)
        {
            if (BrowserCheck(registerDto.Login))
            {
                throw new Exception("Browser already registered");
            }
            else
            {
                var hmac = new HMACSHA512();
                var browser = new Browser
                {
                    Login = registerDto.Login.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                    PasswordSalt = hmac.Key
                };
                _db.Browsers.Add(browser);
                _db.SaveChanges();

                return new BrowserDto { Login = browser.Login, Token = _tokenService.CreateToken(browser) };
            }
        }
        private bool BrowserCheck(string login)
        {
            return _db.Browsers.Any(u => u.Login == login.ToLower());
        }
    }
}