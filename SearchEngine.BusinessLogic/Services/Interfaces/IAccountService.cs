using SearchEngine.Common.DTOs;

namespace SearchEngine.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        BrowserDto Register(RegisterDto browserDto);
        BrowserDto Login(LoginDto loginDto);

    }
}
