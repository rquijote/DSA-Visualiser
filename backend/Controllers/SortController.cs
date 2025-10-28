using Backend.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/sort")]
    public class SortController : ControllerBase
    {
        [HttpPost("bubble")]
        public IActionResult BubbleSortList([FromBody] int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return BadRequest("List cannot be null or empty.");

            BubbleSort bubbleSort = new BubbleSort();
            bubbleSort.Sort(numbers.ToList());

            List<Log> logList = bubbleSort.GetLog();

            return Ok(logList);
        }
    }
}