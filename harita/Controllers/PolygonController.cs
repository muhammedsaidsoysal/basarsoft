using harita.Model;
using harita.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolygonController : ControllerBase
    {
        private readonly PolygonService _polygonService;

        public PolygonController(PolygonService polygonService)
        {
            _polygonService = polygonService;
        }

        [HttpPost]
        public IActionResult Create(Polygon polygon)
        {
            var response = _polygonService.AddPolygon(polygon);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var response = _polygonService.GetPolygonById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _polygonService.GetAllPolygons();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Polygon polygon)
        {
            var response = _polygonService.UpdatePolygon(id, polygon);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var response = _polygonService.DeletePolygon(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
