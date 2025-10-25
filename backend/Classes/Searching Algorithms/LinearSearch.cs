namespace Backend.Classes
{
    public class LinearSearch : SearchingAlgorithm
    {
        public override int Search(List<int> list, int number)
        {
            int index = -1;
            if (list == null) return index;
            for (int i = 0; i < list.Count; i++) 
            {
                incrementIterations();
                AddToLog(list, $"Checking value {list[i]} at index: {i}");
                if (list[i] == number)
                {
                    index = i;
                    AddToLog(list, $"Found {number} at index: {i}");
                    return index;
                }
            }
            AddToLog(list, $"Value: {number} not found in the list.");
            return index;
        }
    }
}
