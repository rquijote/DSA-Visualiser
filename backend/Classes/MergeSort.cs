namespace Backend.Classes
{
    public class MergeSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            if (list.Count <= 1) return list;
            AddToLog(list, $"Splitting list [{string.Join(", ", list)}]");

            int mid = list.Count / 2;
            List<int> left = Sort(list.GetRange(0, mid));
            List<int> right = Sort(list.GetRange(mid, list.Count - mid));

            AddToLog(list, $"Merging left [{string.Join(", ", left)}] and right [{string.Join(", ", right)}]");

            List<int> merged = new List<int>();

            int i = 0; int j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j]) {
                    merged.Add(left[i++]);
                } else
                {
                    merged.Add(right[j++]);
                }
            }

            // Left overs from while loop
            while (i < left.Count) 
            {
                merged.Add(left[i++]);  
            }

            while (j < right.Count)
            {
                merged.Add(right[j++]);
            }

            AddToLog(list, $"Merged result: [{string.Join(", ", merged)}]");
            return merged;
        }
    }
}
