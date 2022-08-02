using SearchEngine.Common.DTOs;
using SearchEngine.Model.DatabaseModels;

namespace SearchEngine.BusinessLogic.Services.Interfaces
{
   public interface IBrowserService
    {
        IEnumerable<BrowserDto> Get();
        BrowserDto Get(int id);
        bool Create(BrowserDto browserDto);
        bool Update(BrowserDto browserDto);
        bool Delete(int id);
    }
}

