using Backend.Classes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/pathfinding")]
    public class Pathfinding : ControllerBase
    {
        [HttpPost("bfs-traverse")]
        public IActionResult BFSTraverse([FromBody] PathfindingRequest request)
        {
            if (request.Graph == null || request.Graph.Count == 0 || request.StartNode == 0)
                return BadRequest("Graph or startNode cannot be empty.");

            BreadthFirstSearch bfs = new BreadthFirstSearch();
            bfs.Traverse(request.Graph, request.StartNode);

            List<Log> logList = bfs.GetLog();
            return Ok(logList);
        }

        [HttpPost("bfs-search")]
        public IActionResult BFSSearch([FromBody] PathfindingRequest request)
        {
            if (request.Graph == null || request.Graph.Count == 0 || request.StartNode == 0 || request.TargetNode == null)
                return BadRequest("Graph, startNode, or targetNode cannot be empty.");

            BreadthFirstSearch bfs = new BreadthFirstSearch();
            bfs.Search(request.Graph, request.StartNode, request.TargetNode.Value);

            List<Log> logList = bfs.GetLog();
            return Ok(logList);
        }

        [HttpPost("dfs-traverse")]
        public IActionResult DFSTraverse([FromBody] PathfindingRequest request)
        {
            if (request.Graph == null || request.Graph.Count == 0 || request.StartNode == 0)
                return BadRequest("Graph or startNode cannot be empty.");

            DepthFirstSearch dfs = new DepthFirstSearch();
            dfs.Traverse(request.Graph, request.StartNode);

            List<Log> logList = dfs.GetLog();
            return Ok(logList);
        }

        [HttpPost("dfs-search")]
        public IActionResult DFSSearch([FromBody] PathfindingRequest request)
        {
            if (request.Graph == null || request.Graph.Count == 0 || request.StartNode == 0 || request.TargetNode == null)
                return BadRequest("Graph, startNode, or targetNode cannot be empty.");

            DepthFirstSearch dfs = new DepthFirstSearch();
            dfs.Search(request.Graph, request.StartNode, request.TargetNode.Value);

            List<Log> logList = dfs.GetLog();
            return Ok(logList);
        }
    }
}
