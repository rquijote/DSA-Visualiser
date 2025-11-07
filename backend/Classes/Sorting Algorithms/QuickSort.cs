namespace Backend.Classes
{
    public class QuickSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            QuickSortRecursion(list, 0, list.Count - 1);
            AddToLog(list,
                $"Quick Sort Completed [{string.Join(", ", list)}]",
                new Dictionary<string, object>());
            return list;
        }

        public void QuickSortRecursion(List<int> list, int start, int end)
        {
            if (start >= end)
            {
                AddToLog(list,
                    $"Base case reached for indices [{start}, {end}]. Segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                    new Dictionary<string, object> { { "highlight", Enumerable.Range(start, Math.Max(0, end - start + 1)).ToList() } });
                return;
            }

            AddToLog(list,
                $"Sorting segment [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                new Dictionary<string, object> { { "highlight", Enumerable.Range(start, end - start + 1).ToList() } });

            int pivotIndex = Partition(list, start, end);

            AddToLog(list,
                $"Pivot placed at index {pivotIndex} with value {list[pivotIndex]}. Left segment: [{string.Join(", ", list.GetRange(start, pivotIndex - start))}], Right segment: [{string.Join(", ", list.GetRange(pivotIndex + 1, end - pivotIndex))}]",
                new Dictionary<string, object> { { "highlight", new List<int> { pivotIndex } } });

            QuickSortRecursion(list, start, pivotIndex - 1);
            QuickSortRecursion(list, pivotIndex + 1, end);
        }

        public int Partition(List<int> list, int start, int end)
        {
            int pivotValue = list[end];
            int i = start - 1;
            int temp;

            AddToLog(list,
                $"Partitioning with pivot {pivotValue} at index {end}.",
                new Dictionary<string, object> { { "highlight", new List<int> { end } } });

            for (int j = start; j < end; j++)
            {
                if (list[j] <= pivotValue)
                {
                    i++;
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;

                    AddToLog(list,
                        $"Swapped {list[i]} (index {i}) with {list[j]} (index {j}). Current segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                        new Dictionary<string, object> { { "highlight", new List<int> { i, j } } });
                }
            }

            i++;
            temp = list[i];
            list[i] = list[end];
            list[end] = temp;

            AddToLog(list,
                $"Moved pivot {pivotValue} to index {i}. Current segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                new Dictionary<string, object> { { "highlight", new List<int> { i, end } } });

            return i;
        }
    }
}
