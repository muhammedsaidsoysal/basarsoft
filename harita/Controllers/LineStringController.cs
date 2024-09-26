using harita.Model;
using harita.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineStringController : ControllerBase
    {
        private readonly LineStringService _lineStringService;

        public LineStringController(LineStringService lineStringService)
        {
            _lineStringService = lineStringService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] LineString lineString)
        {
            var response = _lineStringService.AddLineString(lineString);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var response = _lineStringService.GetLineStringById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _lineStringService.GetAllLineStrings();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] LineString lineString)
        {
            var response = _lineStringService.UpdateLineString(id, lineString);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var response = _lineStringService.DeleteLineString(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
