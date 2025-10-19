namespace Backend
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
                    if (listToSort[j] < listToSort[j-1])
                    {
                        swap(listToSort, j, j-1);
                    }
                }
            }

            //Now sorted list
            SetList(listToSort);

            return listToSort;
        }

        private static void swap(List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
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

        public static void AddToLog(Log logItem)
        {
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

    public class Log(List<int> list, string msg)
    {
        public readonly List<int> _list = list;
        public readonly string _msg = msg;
    }
}
