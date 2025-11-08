namespace Backend.Classes
{
    public class QuickSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            QuickSortRecursion(list, 0, list.Count - 1, 0);
            AddToLog(list,
                $"Quick Sort Completed [{string.Join(", ", list)}]",
                new Dictionary<string, object>());
            return list;
        }

        public void QuickSortRecursion(List<int> list, int start, int end, int depth)
        {
            if (start >= end)
            {
                AddToLog(list,
                    $"Base case reached for indices [{start}, {end}]. Segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                    new Dictionary<string, object> { { "highlight", Enumerable.Range(start, Math.Max(0, end - start + 1)).ToList() }, { "depth", depth } });
                return;
            }

            depth += 1;

            AddToLog(list,
                $"Sorting segment [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                new Dictionary<string, object> { { "highlight", Enumerable.Range(start, end - start + 1).ToList() }, { "depth", depth } });

            int pivotIndex = Partition(list, start, end, depth);

            AddToLog(list,
                $"Pivot placed at index {pivotIndex} with value {list[pivotIndex]}. Left segment: [{string.Join(", ", list.GetRange(start, pivotIndex - start))}], Right segment: [{string.Join(", ", list.GetRange(pivotIndex + 1, end - pivotIndex))}]",
                new Dictionary<string, object> { { "highlight", new List<int> { pivotIndex } } });

            QuickSortRecursion(list, start, pivotIndex - 1, depth);
            QuickSortRecursion(list, pivotIndex + 1, end, depth);
        }

        public int Partition(List<int> list, int start, int end, int depth)
        {
            int pivotValue = list[end];
            int i = start - 1;
            int temp;

            AddToLog(list,
                $"Partitioning with pivot {pivotValue} at index {end}.",
                new Dictionary<string, object> { { "highlight", new List<int> { end } }, { "depth", depth } });

            for (int j = start; j < end; j++)
            {
                if (list[j] <= pivotValue)
                {
                    i++;
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;

                    if (i == j)
                    {
                        AddToLog(list,
                        $"No swap. Current segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                        new Dictionary<string, object> { { "highlight", new List<int> { i, j, end } }, { "depth", depth } });
                    } 
                    else
                    {
                        AddToLog(list,
                        $"Swapped value: {list[i]} (index {i}) with value: {list[j]} (index {j}). Current segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                        new Dictionary<string, object> { { "highlight", new List<int> { i, j, end } }, { "depth", depth } });
                    }
                }
            }

            i++;
            temp = list[i];
            list[i] = list[end];
            list[end] = temp;

            // Still doesn't work? the depth
            AddToLog(list,
                $"Moved pivot {pivotValue} to index {i}. Current segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]",
                new Dictionary<string, object> { { "highlight", new List<int> { i, end } }, { "depth", depth } });

            return i;
        }
    }
}
