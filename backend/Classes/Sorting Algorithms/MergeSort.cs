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

            int moreThanLeftAndRight = 2;

            if (list.Count <= moreThanLeftAndRight)
            {
                AddToLog(
                    list,
                    $"Splitting right side of list [{string.Join(", ", list)}]",
                    new Dictionary<string, object>
                    {
                        { "alertHighlight", Enumerable.Range(mid, list.Count - mid).ToList() },
                        { "depth", depth }
                    }
                );
            }
            else
            {
                AddToLog(
                    list,
                    $"Returning to previous call with original list to sort the right side [{string.Join(", ", list)}]",
                    new Dictionary<string, object>
                    {
                        { "alertHighlight", Enumerable.Range(mid, list.Count - mid).ToList() },
                        { "depth", depth }
                    }
                );
            }

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
                        { "highlight", new List<int>() },
                        { "depth", depth }
                    }
                );

                if (left[i] <= right[j])
                {
                    merged.Add(left[i]);
                    int indexInMerged = merged.Count - 1;

                    var leftoverMessage = (i + 1 < left.Count)
                        ? $"leftovers in left: {string.Join(", ", left.GetRange(i + 1, left.Count - (i + 1)))}. leftovers in right: {string.Join(", ", right.GetRange(j, right.Count - j))}"
                        : "no more leftovers in right";

                    AddToLog(
                        merged,
                        $"Adding {left[i]} from left, {leftoverMessage}",
                        new Dictionary<string, object>
                        {
                            { "highlight", new List<int> { indexInMerged } },
                            { "depth", depth }
                        }
                    );
                    i++;
                }
                else
                {
                    merged.Add(right[j]);
                    int indexInMerged = merged.Count - 1;

                    var leftoverMessage = (j + 1 < right.Count)
                        ? $"leftovers in left: {string.Join(", ", left.GetRange(i, left.Count - i))}. leftovers in right: {string.Join(", ", right.GetRange(j + 1, right.Count - (j + 1)))}"
                        : "no more leftovers in right";

                    AddToLog(
                        merged,
                        $"Adding {right[j]} from right, {leftoverMessage}",
                        new Dictionary<string, object>
                        {
                            { "alertHighlight", new List<int> { indexInMerged } },
                            { "depth", depth }
                        }
                    );
                    j++;
                }
            }

            // Add leftover elements from left
            while (i < left.Count)
            {
                merged.Add(left[i]);
                int indexInMerged = merged.Count - 1;

                string leftoverMessage = (i + 1 < left.Count)
                    ? $"leftovers in left: {string.Join(", ", left.GetRange(i + 1, left.Count - (i + 1)))}. leftovers in right: {string.Join(", ", right.GetRange(j, right.Count - j))}"
                    : "no more leftovers in left";

                AddToLog(
                    merged,
                    $"Adding leftover {left[i]} from left, {leftoverMessage}",
                    new Dictionary<string, object>
                    {
                        { "highlight", new List<int> { indexInMerged } },
                        { "depth", depth }
                    }
                );
                i++;
            }

            // Add leftover elements from right
            while (j < right.Count)
            {
                merged.Add(right[j]);
                int indexInMerged = merged.Count - 1;

                string leftoverMessage = (j + 1 < right.Count && left.Count - i > 0)
                    ? $"leftovers in left: {string.Join(", ", left.GetRange(i, left.Count - i))}. leftovers in right: {string.Join(", ", right.GetRange(j + 1, right.Count - (j + 1)))}"
                    : "no more leftovers in right";

                AddToLog(
                    merged,
                    $"Adding leftover {right[j]} from right, {leftoverMessage}",
                    new Dictionary<string, object>
                    {
                        { "alertHighlight", new List<int> { indexInMerged } },
                        { "depth", depth }
                    }
                );
                j++;
            }

            AddToLog(
                merged,
                $"Finished sorting, merged result: [{string.Join(", ", merged)}]",
                new Dictionary<string, object>
                {
                    { "highlight", new List<int>() },
                    { "depth", depth }
                }
            );

            return merged;
        }
    }
}
