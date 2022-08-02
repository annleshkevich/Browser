using SearchEngine.Model.DatabaseModels;

namespace SearchEngine.BusinessLogic.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Browser browser);
    }
}
