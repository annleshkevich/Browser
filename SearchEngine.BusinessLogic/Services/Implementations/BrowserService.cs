using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SearchEngine.BusinessLogic.Services.Interfaces;
using SearchEngine.Common.DTOs;
using SearchEngine.Model;
using SearchEngine.Model.DatabaseModels;

namespace SearchEngine.BusinessLogic.Services.Implementations
{
    public class BrowserService : IBrowserService
    {
        private readonly BrowserContext _db;
        private readonly IMapper _mapper;
        public BrowserService(BrowserContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public bool Create(BrowserDto browserDto)
        {
            _db.Browsers.Add(_mapper.Map<Browser>(browserDto));
            return Save();
        }
        public bool Delete(int id)
        {
            var browser = _db.Browsers.FirstOrDefault(c => c.Id == id);
            if (browser == null)
                return false;
            _db.Browsers.Remove(browser);
            return Save();
        }
        public IEnumerable<BrowserDto> Get() =>
            _mapper.Map<List<BrowserDto>>(_db.Browsers.AsNoTracking().ToList());
        public BrowserDto Get(int id) =>
            _mapper.Map<BrowserDto>(_db.Browsers.FirstOrDefault(u => u.Id == id)!);
        public bool Update(BrowserDto browserDto)
        {
            _db.Update(browserDto);
            return Save();
        }
        public bool Save()
        {
            var saved = _db.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
