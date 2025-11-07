namespace Backend.Classes
{
    public class BinarySearch : SearchingAlgorithm
    {
        public override int Search(List<int> list, int number)
        {
            int low = 0, high = list.Count - 1;

            while (low <= high)
            {
                incrementIterations();
                int mid = low + (high - low) / 2;

                AddToLog(list,
                    $"Checking middle index: {mid}, value: {list[mid]}",
                    new Dictionary<string, object> { { "highlight", new List<int> { mid } } });

                if (list[mid] == number)
                {
                    AddToLog(list,
                        $"Found value: {number} at index: {mid}",
                        new Dictionary<string, object> { { "highlight", new List<int> { mid } } });
                    return mid;
                }

                if (list[mid] < number)
                {
                    AddToLog(list,
                        $"Value: {list[mid]} is smaller than {number}. Changing low: {low} to {mid + 1}",
                        new Dictionary<string, object> { { "highlight", new List<int> { mid } } });
                    low = mid + 1;
                }
                else
                {
                    AddToLog(list,
                        $"Value: {list[mid]} is larger than {number}. Changing high: {high} to {mid - 1}",
                        new Dictionary<string, object> { { "highlight", new List<int> { mid } } });
                    high = mid - 1;
                }
            }

            AddToLog(list,
                $"Couldn't find value: {number}",
                new Dictionary<string, object>());
            return -1;
        }
    }
}
