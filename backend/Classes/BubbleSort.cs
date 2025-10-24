namespace Backend.Classes
{
    public class BubbleSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                AddToLog(list, $"Starting pass {i + 1} over the list: [{string.Join(", ", list)}]");
                bool swappedThisPass = false;

                for (int j = 1; j < list.Count - i; j++)
                {
                    if (list[j] < list[j - 1])
                    {
                        Swap(list, j, j - 1);
                        swappedThisPass = true;
                    }
                    else
                    {
                        AddToLog(list, $"No swap needed between index {j - 1} ({list[j - 1]}) and {j} ({list[j]})");
                    }
                }

                if (!swappedThisPass)
                {
                    AddToLog(list, $"No swaps in pass {i + 1}, list is sorted.");
                    break;
                }
            }

            SetList(list);
            AddToLog(list, $"Final sorted list: [{string.Join(", ", list)}]");
            return list;
        }

        private void Swap(List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            AddToLog(list, $"Swapped index {index1} ({list[index1]}) with index {index2} ({list[index2]}). Current list: [{string.Join(", ", list)}]");
        }
    }
}

