using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Services;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngestsController : ControllerBase
    {
        private readonly IIngestService _ingestService;
        public IngestsController(IIngestService ingestService)
        {
            _ingestService = ingestService;
        }
        [HttpGet]
        public IActionResult Get()//nháp
        {
            var entities = _ingestService.Get();
            return Ok(entities);
        }
    }
}
