namespace Backend.Classes
{
    public class InsertionSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                // temp saves the current list[i] value
                int temp = list[i];
                // j is saved which takes values on the left
                int j = i - 1;
                if (j >= 0 && list[j] > temp)
                {
                    // while there are left numbers and triggers when temp needs to be moved
                    while (j >= 0 && list[j] > temp)
                    {
                        list[j + 1] = list[j];
                        AddToLog(list, $"Moved {list[j]} to the right.");
                        // decrements until it's not a lower int to temp
                        j--;
                    }
                } else
                {
                    AddToLog(list, "No changes");
                }
                // uses that existing j value to find the left value of the index to replace.
                // + 1 to get to the correct index. 
                list[j + 1] = temp;
            }

            return list;
        }
    }
}
