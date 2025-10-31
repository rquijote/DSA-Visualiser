namespace Backend.Classes
{
    public class DepthFirstSearch : PathfindingAlgorithm
    {
        public override List<int> Traverse(Dictionary<int, List<int>> graph, int startNode)
        {
            List<int> result = DFS_Helper(graph, startNode);
            return result;
        }

        public override List<int> Search(Dictionary<int, List<int>> graph, int startNode, int target)
        {
            List<int> result = DFS_Helper(graph, startNode, target);
            return result;
        }

        private List<int> DFS_Helper(Dictionary<int, List<int>> graph, int startNode, int? targetNode = null)
        {
            HashSet<int> visited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            if (!graph.ContainsKey(startNode))
            {
                AddToLog(result, "No starting node found.", new List<int>());
                return result;
            }

            stack.Push(startNode);
            visited.Add(startNode);

            AddToLog(visited.ToList(), $"Visited node initially: {string.Join(",", visited)}", visited.ToList());

            while (stack.Count > 0)
            {
                int current = stack.Pop();
                result.Add(current);
                IncrementIterations();

                AddToLog(result, $"Result is currently: [{string.Join(", ", result)}]", new List<int> { current });

                if (current == targetNode)
                {
                    return result;
                }

                foreach (int node in graph[current])
                {
                    if (!visited.Contains(node))
                    {
                        stack.Push(node);
                        visited.Add(node);
                        AddToLog(new List<int> { node }, $"Visited and pushed node: {node}", new List<int> { node });
                    }
                    else
                    {
                        AddToLog(new List<int> { node }, $"Skipped already visited node: {node}", new List<int> { node });
                    }
                }

                AddToLog(stack.ToList(), $"Stack now: [{string.Join(", ", stack)}]", stack.ToList());
            }

            AddToLog(result, $"Completed traversal: [{string.Join(", ", stack)}]", new List<int>());

            if (targetNode.HasValue && !result.Contains(targetNode.Value))
            {
                AddToLog(result, $"Target node {targetNode.Value} not found in graph.", new List<int>());
            }

            return result;
        }
    }
}
