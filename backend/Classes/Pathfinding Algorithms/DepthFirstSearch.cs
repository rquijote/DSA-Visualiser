namespace Backend.Classes
{
    public class DepthFirstSearch : PathfindingAlgorithm
    {
        public override List<int> Traverse(Dictionary<int, List<int>> graph, int startNode) =>
            DFS_Helper(graph, startNode);

        public override List<int> Search(Dictionary<int, List<int>> graph, int startNode, int target) =>
            DFS_Helper(graph, startNode, target);

        private List<int> DFS_Helper(Dictionary<int, List<int>> graph, int startNode, int? targetNode = null)
        {
            HashSet<int> visited = new HashSet<int>(); 
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            if (!graph.ContainsKey(startNode))
            {
                AddToLog(result, "No starting node found.", new Dictionary<string, object>());
                return result;
            }

            stack.Push(startNode);

            while (stack.Count > 0)
            {
                int current = stack.Pop();
                visited.Add(current);
                result.Add(current);

                AddToLog(
                result,
                 $"Adding {current} to result: [{string.Join(", ", result)}]",
                new Dictionary<string, object> {
                    { "visitedHighlight", visited.ToList() },       
                    { "toVisitHighlight", stack.Reverse().ToList() } 
                });


                if (current == targetNode) return result;

                foreach (int neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor) && !stack.Contains(neighbor))
                    {
                        stack.Push(neighbor);

                        AddToLog(
                            result,
                            $"Pushed node {neighbor} onto to visit stack",
                            new Dictionary<string, object> {
                        { "visitedHighlight", visited.ToList() },
                        { "toVisitHighlight", stack.Reverse().ToList() }
                            });
                    }
                }
            }

            AddToLog(
                result,
                $"Completed traversal: [{string.Join(", ", result)}]",
                new Dictionary<string, object> {
            { "visitedHighlight", visited.ToList() },
            { "toVisitHighlight", new List<int>() } 
                });

            if (targetNode.HasValue && !result.Contains(targetNode.Value))
            {
                AddToLog(
                    result,
                    $"Target node {targetNode.Value} not found in graph.",
                    new Dictionary<string, object>());
            }

            return result;
        }
    }
}
