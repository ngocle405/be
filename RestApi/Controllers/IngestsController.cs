using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Data.Entities;
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
        [HttpGet("GetBroadcastProgram")]
        public IActionResult GetBroadcastProgram()
        {
            var rs = _ingestService.GetBroadcastProgram();
            return Ok(rs);
        }
        [HttpGet("GetIngestGenre")]
        public IActionResult GetIngestGenre()
        {
            return Ok(_ingestService.GetIngestGenre());
        }
        [HttpPost]
        public IActionResult AddIngest([FromBody]Ingest ingest)
        {
            var rs=_ingestService.AddIngest(ingest);
            return StatusCode(201, rs);
        }

    }
}
