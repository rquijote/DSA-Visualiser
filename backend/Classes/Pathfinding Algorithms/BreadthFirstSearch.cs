namespace Backend.Classes
{
    public class BreadthFirstSearch : PathfindingAlgorithm
    {
        public override List<int> Traverse(Dictionary<int, List<int>> graph, int startNode)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            List<int> result = new List<int>();

            if (!graph.ContainsKey(startNode))
            {
                AddToLog(result, "No starting node found.");
                return result;
            }

            queue.Enqueue(startNode);
            visited.Add(startNode);

            AddToLog(visited.ToList(), $"Visited node initially: {string.Join(",", visited)}");

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                result.Add(current);
                AddToLog(result, $"Result is currently: [{string.Join(",", result)}]");

                foreach (int node in graph[current])
                {
                    if (!visited.Contains(node))
                    {
                        queue.Enqueue(node);
                        visited.Add(node);
                        AddToLog(new List<int> { node }, $"Visited and enqueued node: {node}");
                    }
                    else
                    {
                        AddToLog(new List<int> { node }, $"Skipped already visited node: {node}");
                    }
                }

                AddToLog(queue.ToList(), $"Queue now: [{string.Join(",", queue)}]");
            }
            AddToLog(result, $"Completed traversal: [{string.Join(",", queue)}]");
            return result;
        }
    }
}

