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
            HashSet<int> visited = new HashSet<int>(); // All visited nodes
            Stack<int> stack = new Stack<int>(); // To be visited nodes
            List<int> result = new List<int>(); // To return list

            if (!graph.ContainsKey(startNode))
            {
                AddToLog(result, "No starting node found.", new Dictionary<string, object>());
                return result;
            }

            stack.Push(startNode);
            visited.Add(startNode);

            AddToLog(visited.ToList(),
                $"Visited node initially: {string.Join(",", visited)}",
                new Dictionary<string, object> { { "visitedHighlight", visited.ToList() }, { "stackHighlight", stack.ToList() } });

            while (stack.Count > 0)
            {
                int current = stack.Pop();
                result.Add(current);
                IncrementIterations();

                AddToLog(result,
                    $"Result is currently: [{string.Join(", ", result)}]",
                    new Dictionary<string, object> { { "visitedHighlight", visited.ToList() }, { "stackHighlight", stack.ToList() } });

                if (current == targetNode) return result;

                foreach (int node in graph[current])
                {
                    if (!visited.Contains(node))
                    {
                        stack.Push(node);
                        visited.Add(node);
                        AddToLog(new List<int> { node },
                            $"Visited and pushed node: {node}",
                            new Dictionary<string, object> { { "visitedHighlight", visited.ToList() }, { "stackHighlight", stack.ToList() } });
                    }
                    else
                    {
                        AddToLog(new List<int> { node },
                            $"Skipped already visited node: {node}",
                            new Dictionary<string, object> { { "visitedHighlight", visited.ToList() }, { "stackHighlight", stack.ToList() } });
                    }
                }

                AddToLog(stack.ToList(),
                    $"Stack now: [{string.Join(", ", stack)}]",
                    new Dictionary<string, object> { { "visitedHighlight", visited.ToList() }, { "stackHighlight", stack.ToList() } });
            }

            AddToLog(result,
                $"Completed traversal: [{string.Join(", ", result)}]",
                new Dictionary<string, object> { { "visitedHighlight", visited.ToList() }, { "stackHighlight", stack.ToList() } });

            if (targetNode.HasValue && !result.Contains(targetNode.Value))
            {
                AddToLog(result,
                    $"Target node {targetNode.Value} not found in graph.",
                    new Dictionary<string, object>());
            }

            return result;
        }
    }
}
