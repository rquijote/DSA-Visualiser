namespace Backend.Classes
{
    public class SelectionSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    Swap(list, i, min);
                }
                else
                {
                    AddToLog(list, $"No swap needed for index {i} ({list[i]}). Current list: [{string.Join(", ", list)}]", new List<int> { i });
                }
            }

            AddToLog(list, $"Sorting complete. Final list: [{string.Join(", ", list)}]", new List<int>());
            return list;
        }

        private void Swap(List<int> list, int i, int min)
        {
            int temp = list[i];
            list[i] = list[min];
            list[min] = temp;
            AddToLog(list, $"Swapped index {i} ({list[i]}) with index {min} ({list[min]}). Current list: [{string.Join(", ", list)}]", new List<int> { i, min });
        }
    }
}