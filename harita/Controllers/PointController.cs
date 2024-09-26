using harita.Services;
using harita.Model;
using Microsoft.AspNetCore.Mvc;

namespace harita.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly PointService _pointService;
        public PointController(PointService pointService)
        {
            _pointService = pointService;
        }

        [HttpPost]
        public IActionResult AddPoint(Point point)
        {
            var response = _pointService.Add(point);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePoint(long id, Point uppoint)
        {
            var response = _pointService.Update(id, uppoint);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePoint(long id)
        {
            var response = _pointService.Delete(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public IActionResult GetAllPoint()
        {
            var response = _pointService.GetAll();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetPointByIdUOW(long id)
        {
            var response = _pointService.GetById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
