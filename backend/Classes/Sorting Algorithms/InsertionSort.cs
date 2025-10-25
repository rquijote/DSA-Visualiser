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
                    list[j + 1] = list[j];
                    AddToLog(list, $"Shifted {list[j]} from index {j} to index {j + 1}");
                    j--;
                    moved = true;
                }

                list[j + 1] = temp;

                if (moved)
                {
                    AddToLog(list, $"Inserted {temp} at index {j + 1}. Current list: [{string.Join(", ", list)}]");
                }
                else
                {
                    AddToLog(list, $"No movement needed for {temp} at index {i}");
                }
            }

            AddToLog(list, $"Final sorted list: [{string.Join(", ", list)}]");
            return list;
        }
    }
}

