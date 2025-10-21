namespace Backend.Classes
{
    public static class BubbleSort
    {
        private static List<int> _list = [];
        private static int _count = 0;
        private static List<Log> _log = [];


        public static List<int> Sort(List<int> listToSort)
        {
            for (int i = 0; i < listToSort.Count; i++)
            {
                for (int j = 1; j < listToSort.Count; j++)
                {
                    IncrementOpCount();
                    if (listToSort[j] < listToSort[j - 1])
                    {
                        swap(listToSort, j, j - 1);
                    }
                }
            }

            //Now bubble sorted list
            SetList(listToSort);

            return listToSort;
        }

        private static void swap(List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            AddToLog(list, $"Swapped {list[index1]} and {list[index2]}");
        }

        public static List<int> GetList()
        {
            return _list;
        }

        public static void SetList(List<int> list)
        {
            _list = list;
        }

        public static int GetOpCount()
        {
            return _count;
        }

        public static void IncrementOpCount()
        {
            _count++;
        }

        public static void AddToLog(List<int> logList, string msg)
        {
            Log logItem = new Log(logList, msg);
            _log.Add(logItem);
        }

        public static List<Log> GetLog()
        {
            return _log;
        }

        public static void Reset()
        {
            _count = 0;
            _log = [];
            _list = [];
        }
    }
}
