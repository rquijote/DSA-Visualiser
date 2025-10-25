namespace Backend.Classes
{
    public class QuickSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            QuickSortRecursion(list, 0, list.Count - 1);
            AddToLog(list, $"Quick Sort Completed [{string.Join(", ", list.GetRange(0,list.Count))}]");
            return list;
        }

        public void QuickSortRecursion(List<int> list, int start, int end)
        {
            if (start >= end)
            {
                AddToLog(list, $"Base case reached for indices [{start}, {end}]. Segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]");
                return;
            }

            AddToLog(list, $"Sorting segment [{string.Join(", ", list.GetRange(start, end - start + 1))}]");

            int pivotIndex = Partition(list, start, end);

            AddToLog(list, $"Pivot placed at index {pivotIndex} with value {list[pivotIndex]}. Left segment: [{string.Join(", ", list.GetRange(start, pivotIndex - start))}], Right segment: [{string.Join(", ", list.GetRange(pivotIndex + 1, end - pivotIndex))}]");

            QuickSortRecursion(list, start, pivotIndex - 1);
            QuickSortRecursion(list, pivotIndex + 1, end);
        }

        public int Partition(List<int> list, int start, int end)
        {
            int pivotValue = list[end];
            int i = start - 1;
            int temp;

            AddToLog(list, $"Partitioning with pivot {pivotValue} at index {end}.");

            for (int j = start; j < end; j++)
            {
                if (list[j] <= pivotValue)
                {
                    i++;
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    AddToLog(list, $"Swapped {list[i]} (index {i}) with {list[j]} (index {j}). Current segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]");
                }
            }

            i++;
            temp = list[i];
            list[i] = list[end];
            list[end] = temp;
            AddToLog(list, $"Moved pivot {pivotValue} to index {i}. Current segment: [{string.Join(", ", list.GetRange(start, end - start + 1))}]");

            return i;
        }
    }
}
