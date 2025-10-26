namespace Backend.Classes
{
    public class DepthFirstSearch : PathfindingAlgorithm
    {
        public override List<int> Traverse(Dictionary<int, List<int>> graph, int startNode)
        {
            HashSet<int> visited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();
            List<int> result = new List<int>();

            if (!graph.ContainsKey(startNode))
            {
                AddToLog(result, "No starting node found.");
                return result;
            }

            stack.Push(startNode);
            visited.Add(startNode);

            AddToLog(visited.ToList(), $"Visited node initially: {string.Join(",", visited)}");

            while (stack.Count > 0)
            {
                int current = stack.Pop();
                result.Add(current);

                AddToLog(result, $"Result is currently: [{string.Join(", ", result)}]");

                foreach (int node in graph[current])
                {
                    if (!visited.Contains(node))
                    {
                        stack.Push(node);
                        visited.Add(node);
                        AddToLog(new List<int> { node }, $"Visited and pushed node: {node}");
                    }
                    else
                    {
                        AddToLog(new List<int> { node }, $"Skipped already visited node: {node}");
                    }
                }

                AddToLog(stack.ToList(), $"Stack now: [{string.Join(", ", stack)}]");
            }

            AddToLog(result, $"Completed traversal: [{string.Join(", ", stack)}]");
            return result;
        }
    }
}
