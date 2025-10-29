using Backend.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class Pathfinding : ControllerBase
    {
        [HttpPost("bfs-traverse")]
        public IActionResult BFSTraverse([FromBody] Dictionary<int, List<int>> graph, int startNode)
        {
            if (graph.Count <= 0 || startNode == 0) return BadRequest("Graph or startNode cannot be empty.");
            BreadthFirstSearch bfs = new BreadthFirstSearch();
            bfs.Traverse(graph, startNode);

            List<Log> logList = bfs.GetLog();

            return Ok(logList);
        }

        [HttpPost("bfs-search")]
        public IActionResult BFSSearch([FromBody] Dictionary<int, List<int>> graph, int startNode, int targetNode)
        {
            if (graph.Count <= 0 || startNode == 0 || targetNode == 0) return BadRequest("List cannot be null or empty.");

            BreadthFirstSearch bfs = new BreadthFirstSearch();
            bfs.Search(graph, startNode, targetNode);

            List<Log> logList = bfs.GetLog();

            return Ok(logList);
        }

        [HttpPost("dfs-traverse")]
        public IActionResult DFSTraverse([FromBody] Dictionary<int, List<int>> graph, int startNode)
        {
            if (graph.Count <= 0 || startNode == 0) return BadRequest("Graph or startNode cannot be empty.");
            
            DepthFirstSearch dfs = new DepthFirstSearch();
            dfs.Traverse(graph, startNode);
            List<Log> logList = dfs.GetLog();

            return Ok(logList);
        }

        [HttpPost("dfs-search")]
        public IActionResult DFSSearch([FromBody] Dictionary<int, List<int>> graph, int startNode, int targetNode)
        {
            if (graph.Count <= 0 || startNode == 0 || targetNode == 0) return BadRequest("List cannot be null or empty.");

            DepthFirstSearch dfs = new DepthFirstSearch();
            dfs.Search(graph, startNode, targetNode);
            List<Log> logList = dfs.GetLog();

            return Ok(logList);
        }
    }
}
