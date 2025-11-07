namespace Backend.Classes
{
    public class LinearSearch : SearchingAlgorithm
    {
        public override int Search(List<int> list, int number)
        {
            if (list == null) return -1;

            for (int i = 0; i < list.Count; i++)
            {
                incrementIterations();

                AddToLog(list,
                    $"Checking value {list[i]} at index: {i}",
                    new Dictionary<string, object> { { "highlight", new List<int> { i } } });

                if (list[i] == number)
                {
                    AddToLog(list,
                        $"Found {number} at index: {i}",
                        new Dictionary<string, object> { { "highlight", new List<int> { i } } });
                    return i;
                }
            }

            AddToLog(list,
                $"Value: {number} not found in the list.",
                new Dictionary<string, object>());
            return -1;
        }
    }
}
