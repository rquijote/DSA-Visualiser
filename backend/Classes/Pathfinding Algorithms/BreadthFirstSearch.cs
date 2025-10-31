namespace Backend.Classes
{
    public class BreadthFirstSearch : PathfindingAlgorithm
    {
        public override List<int> Traverse(Dictionary<int, List<int>> graph, int startNode)
        {
            return BFS_Helper(graph, startNode);
        }

        public override List<int> Search(Dictionary<int, List<int>> graph, int startNode, int target)
        {
            return BFS_Helper(graph, startNode, target);
        }

        private List<int> BFS_Helper(Dictionary<int, List<int>> graph, int startNode, int? targetNode = null)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            List<int> result = new List<int>();

            if (!graph.ContainsKey(startNode))
            {
                AddToLog(result, "No starting node found.", new List<int>());
                return result;
            }

            queue.Enqueue(startNode);
            visited.Add(startNode);

            AddToLog(visited.ToList(), $"Visited node initially: {string.Join(",", visited)}", visited.ToList());

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
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
                        queue.Enqueue(node);
                        visited.Add(node);
                        AddToLog(new List<int> { node }, $"Visited and enqueued node: {node}", new List<int> { node });
                    }
                    else
                    {
                        AddToLog(new List<int> { node }, $"Skipped already visited node: {node}", new List<int> { node });
                    }
                }

                AddToLog(queue.ToList(), $"Queue now: [{string.Join(", ", queue)}]", queue.ToList());
            }

            AddToLog(result, $"Completed traversal: [{string.Join(", ", queue)}]", new List<int>());

            if (targetNode.HasValue && !result.Contains(targetNode.Value))
            {
                AddToLog(result, $"Target node {targetNode.Value} not found in graph.", new List<int>());
            }

            return result;
        }
    }
}
