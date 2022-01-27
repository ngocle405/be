using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Services;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IcardService _cardService;
        public CardsController(IcardService cardService)
        {
            _cardService= cardService;  
        }
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _cardService.Get();
            return Ok(entities);
        }
        [HttpGet("GetCardById/{cardId}")]
        public IActionResult GetCardById(int cardId)
        {
            var rs = _cardService.GetCardById(cardId);
            return Ok(rs);
        }
    }
}
