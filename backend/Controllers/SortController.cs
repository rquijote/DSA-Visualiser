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

        [HttpPost("insertion")]
        public IActionResult InsertionSortList([FromBody] int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return BadRequest("List cannot be null or empty.");

            InsertionSort insertionSort = new InsertionSort();
            insertionSort.Sort(numbers.ToList());

            List<Log> logList = insertionSort.GetLog();

            return Ok(logList);
        }

        [HttpPost("merge")]
        public IActionResult MergeSortList([FromBody] int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return BadRequest("List cannot be null or empty.");

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(numbers.ToList());

            List<Log> logList = mergeSort.GetLog();

            return Ok(logList);
        }

        [HttpPost("quick")]
        public IActionResult QuickSortList([FromBody] int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return BadRequest("List cannot be null or empty.");

            QuickSort quickSort = new QuickSort();
            quickSort.Sort(numbers.ToList());

            List<Log> logList = quickSort.GetLog();

            return Ok(logList);
        }

        [HttpPost("selection")]
        public IActionResult SelectionSortList([FromBody] int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return BadRequest("List cannot be null or empty.");

            SelectionSort selectionSort = new SelectionSort();
            selectionSort.Sort(numbers.ToList());

            List<Log> logList = selectionSort.GetLog();

            return Ok(logList);
        }

    }
}