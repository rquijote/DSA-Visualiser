namespace Backend.Classes
{
    public class PathfindingAlgorithm
    {
        private int _iterations = 0;
        private List<Log> _log = [];

        public virtual List<int> Traverse(Dictionary<int, List<int>> graph, int startNode)
        {
            List<int> list = new List<int>();
            return list;
        }

        public int GetIterations()
        {
            return _iterations;
        }

        public void incrementIterations()
        {
            _iterations++;
        }
        public void AddToLog(List<int> logList, string msg)
        {
            Log logItem = new Log(new List<int>(logList), msg);
            _log.Add(logItem);
        }

        public List<Log> GetLog()
        {
            return _log;
        }
    }
}
