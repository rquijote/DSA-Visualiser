namespace Backend.Classes
{
    public class MergeSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            // Base case 
            if (list.Count <= 1) return list;
            AddToLog(list, $"List to split [{string.Join(", ", list)}]", new List<int>());

            AddToLog(list, $"Splitting list [{string.Join(", ", list)}]", new List<int>());

            int mid = list.Count / 2;
            List<int> left = Sort(list.GetRange(0, mid));
            List<int> right = Sort(list.GetRange(mid, list.Count - mid));

            List<int> merged = new List<int>();

            int i = 0; int j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (merged.Count == 0)
                {
                    AddToLog([left[i], right[j]], $"Comparing {left[i]} (left) and {right[j]} (right)", new List<int> { });
                } else
                {
                    AddToLog(merged, $"Comparing {left[i]} (left) and {right[j]} (right)", new List<int> { });
                }
                
                if (left[i] <= right[j])
                {
                    merged.Add(left[i]);
                    AddToLog(merged, $"Adding {left[i]} (left) to merged list", new List<int> { });
                    i++;
                }
                else
                {
                    merged.Add(right[j]);
                    AddToLog(merged, $"Adding {right[j]} (right) to merged list", new List<int> { });
                    j++;
                }
            }

            while (i < left.Count)
            {
                merged.Add(left[i++]);
            }

            while (j < right.Count)
            {
                merged.Add(right[j++]);
            }

            AddToLog(merged, $"Merged result: [{string.Join(", ", merged)}]", new List<int>());
            return merged;
        }
    }
}