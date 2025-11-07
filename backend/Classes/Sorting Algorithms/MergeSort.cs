namespace Backend.Classes
{
    public class MergeSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            return MergeSortRecursion(list, 0);
        }

        private List<int> MergeSortRecursion(List<int> list, int depth)
        {
            if (list.Count <= 1)
                return list;

            int mid = list.Count / 2;

            AddToLog(
                list,
                $"Splitting left side of list [{string.Join(", ", list)}]",
                new Dictionary<string, object>
                {
                    { "highlight", Enumerable.Range(0, mid).ToList() },
                    { "depth", depth }
                }
            );

            List<int> left = MergeSortRecursion(list.GetRange(0, mid), depth + 1);

            AddToLog(
                list,
                $"Splitting right side of list [{string.Join(", ", list)}]",
                new Dictionary<string, object>
                {
                    { "highlight", Enumerable.Range(mid, list.Count - mid).ToList() },
                    { "depth", depth }
                }
            );

            List<int> right = MergeSortRecursion(list.GetRange(mid, list.Count - mid), depth + 1);

            List<int> merged = new List<int>();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                AddToLog(
                    merged.Count == 0 ? new List<int> { left[i], right[j] } : merged,
                    $"Comparing {left[i]} (left) and {right[j]} (right)",
                    new Dictionary<string, object>
                    {
                        { "highlight", new List<int> { left[i], right[j] } },
                        { "depth", depth }
                    }
                );

                if (left[i] <= right[j])
                    merged.Add(left[i++]);
                else
                    merged.Add(right[j++]);
            }

            while (i < left.Count)
                merged.Add(left[i++]);

            while (j < right.Count)
                merged.Add(right[j++]);

            AddToLog(
                merged,
                $"Merged result: [{string.Join(", ", merged)}]",
                new Dictionary<string, object>
                {
                    { "highlight", merged.ToList() },
                    { "depth", depth }
                }
            );

            return merged;
        }
    }
}
