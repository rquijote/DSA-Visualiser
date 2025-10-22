namespace Backend.Classes
{
    public class SelectionSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            // Outer for loop to iterate over the list. 
            for (int i = 0; i < list.Count - 1; i++)
            {
                // Start of outer for loop is the lowest
                int min = i;
                // Inner for loop starts on the next int of the starting.
                for (int j = i + 1; j < list.Count; j++)
                {
                    // if the smallest is greater than j, swap for ascending order. Puts the highest val
                    // where list[j] towards the back. 
                    if (list[min] > list[j])
                    {
                        // min is changed to the j index value
                        min = j;
                    }
                }
                if (list[min] != list[i])
                {
                    Swap(list, i, min);
                } else
                {
                    AddToLog(list, "No swap");
                }
            }
            return list;
        }

        public void Swap(List<int> list, int i, int min)
        {
            // Sets temp to list[i] before replacing it
            int temp = list[i];
            // New smallest int is set at list[i]
            list[i] = list[min];
            // Old location of the smallestInt is replaced with the bigger int. 
            list[min] = temp;
            AddToLog(list, $"Swapped {list[i]} and {list[min]}");
        }
    }
}
