namespace Backend.Classes
{
    public class SelectionSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i;
                int originalIndex = i; // store original position for highlighting
                AddToLog(list,
                    $"Starting position {i} with value {list[i]}",
                    new Dictionary<string, object> { { "highlight", new List<int> { i } } });

                for (int j = i + 1; j < list.Count; j++)
                {
                    // Hacky? If min is the original i, stay blue. Avoids min cause original i to be alertHighlighted.
                    var alert = min != i ? new List<int> { min } : new List<int>();

                    AddToLog(list,
                        $"Comparing min value {list[min]} to value {list[j]}",
                        new Dictionary<string, object>
                        {
                            { "highlight", new List<int> { i, j } },
                            { "alertHighlight", alert }
                        });

                    if (list[j] < list[min])
                    {
                        min = j;
                        AddToLog(list,
                            $"New min found at index {j} ({list[j]})",
                            new Dictionary<string, object> { { "alertHighlight", new List<int> { min } } });
                    }
                }

                if (min != i)
                {
                    Swap(list, i, min);
                }
                else
                {
                    AddToLog(list,
                        $"No swap needed for index {i} ({list[i]})",
                        new Dictionary<string, object> { { "highlight", new List<int> { i } } });
                }
            }

            AddToLog(list,
                $"Sorting complete. Final list: [{string.Join(", ", list)}]",
                new Dictionary<string, object>());

            return list;
        }

        private void Swap(List<int> list, int i, int min)
        {
            int temp = list[i];
            list[i] = list[min];
            list[min] = temp;

            AddToLog(list,
                $"Swapped index {i} ({list[i]}) with index {min} ({list[min]})",
                new Dictionary<string, object> { { "alertHighlight", new List<int> { i, min } } });
        }
    }
}
