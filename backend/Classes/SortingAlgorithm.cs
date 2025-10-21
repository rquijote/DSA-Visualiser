namespace Backend.Classes
{
    public class SortingAlgorithm
    {
        private List<int> _list = [];
        private int _count = 0;
        private List<Log> _log = [];

        public virtual List<int> Sort(List<int> listToSort)
        {
            return listToSort;
        }

        public List<int> GetList()
        {
            return _list;
        }

        public void SetList(List<int> list)
        {
            _list = list;
        }

        public int GetOpCount()
        {
            return _count;
        }

        public void IncrementOpCount()
        {
            _count++;
        }

        public void AddToLog(List<int> logList, string msg)
        {
            Log logItem = new Log(logList, msg);
            _log.Add(logItem);
        }

        public List<Log> GetLog()
        {
            return _log;
        }

        public void Reset()
        {
            _count = 0;
            _log = [];
            _list = [];
        }
    }
}
