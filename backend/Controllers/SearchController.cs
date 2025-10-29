using Backend.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        [HttpPost("linear")]
        public IActionResult LinearSearch([FromBody] SearchRequest request)
        {
            if (request.Numbers == null || request.Numbers.Length <= 0) return BadRequest("List cannot be null or empty.");

            LinearSearch linearSearch = new LinearSearch();
            linearSearch.Search(request.Numbers.ToList(), request.Target);

            List<Log> logList = linearSearch.GetLog();

            return Ok(logList);
        }

        [HttpPost("binary")]
        public IActionResult BinarySearch([FromBody] SearchRequest request)
        {
            if (request.Numbers == null || request.Numbers.Length <= 0) return BadRequest("List cannot be null or empty.");

            BinarySearch binarySearch = new BinarySearch();
            binarySearch.Search(request.Numbers.ToList(), request.Target);

            List<Log> logList = binarySearch.GetLog();

            return Ok(logList);
        }
    }
}
