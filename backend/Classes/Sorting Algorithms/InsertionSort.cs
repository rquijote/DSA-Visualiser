namespace Backend.Classes
{
    public class InsertionSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int temp = list[i];
                int j = i - 1;
                bool moved = false;

                while (j >= 0 && list[j] > temp)
                {
                    AddToLog(list, $"index at {j+1} is bigger than index at {j}, index {j} shifted to index {j + 1}", new List<int> { j, j + 1 });
                    list[j + 1] = list[j];
                    AddToLog(list, $"Shifted {list[j]} from index {j} to index {j + 1}", new List<int> { j, j + 1 });
                    j--;
                    moved = true;
                }

                list[j + 1] = temp;

                if (moved)
                {
                    AddToLog(list, $"Inserted {temp} at index {j + 1}. Current list: [{string.Join(", ", list)}]", new List<int> { j + 1 });
                }
                else
                {
                    AddToLog(list, $"No changes needed for {temp} at index {i}", new List<int> { i });
                }
            }

            AddToLog(list, $"Final sorted list: [{string.Join(", ", list)}]", new List<int>());
            return list;
        }
    }
}