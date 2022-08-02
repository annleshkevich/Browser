using Microsoft.AspNetCore.Mvc;
using SearchEngine.BusinessLogic.Services.Interfaces;
using SearchEngine.Common.DTOs;
using SearchEngine.Model.DatabaseModels;

namespace Search_Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrowsersController : ControllerBase
    {
        private readonly IBrowserService _browserService;
        public BrowsersController(IBrowserService browserService)
        {
            _browserService = browserService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BrowserDto>> Get()
        {
            return Ok(_browserService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var browser = _browserService.Get(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(browser);
        }

        [HttpPost]
        public IActionResult Post(BrowserDto browserDto)
        {
            return _browserService.Create(browserDto) ? Ok("Browser has been created") : BadRequest("Browser not created");
        }

        [HttpPut]
        public IActionResult Put(BrowserDto browserDto)           
        {
            return  _browserService.Update(browserDto)? Ok("Browser has been updated") : BadRequest("Browser not updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            return _browserService.Delete(id) ? Ok("Browser has been removed") : BadRequest("Browser not deleted");
        }
    }
}
