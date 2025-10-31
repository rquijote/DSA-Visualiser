namespace Backend.Classes
{
    public class SortingAlgorithm
    {
        private List<int> _list = [];
        private List<Log> _log = [];

        public virtual List<int> Sort(List<int> list)
        {
            return list;
        }

        public List<int> GetList()
        {
            return _list;
        }

        public void SetList(List<int> list)
        {
            _list = list;
        }

        public void AddToLog(List<int> logList, string msg, List<int> highlight)
        {
            Log logItem = new Log(new List<int>(logList), msg, new List<int>(highlight));
            _log.Add(logItem);
        }

        public List<Log> GetLog()
        {
            return _log;
        }

        public void Reset()
        {
            _log = [];
            _list = [];
        }
    }
}
