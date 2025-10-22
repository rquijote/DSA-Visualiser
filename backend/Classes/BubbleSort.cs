namespace Backend.Classes
{
    public class BubbleSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j] < list[j - 1])
                    {
                        Swap(list, j, j - 1);
                    } else
                    {
                        AddToLog(list, "No swap");
                    }
                }
            }

            //Now bubble sorted list
            SetList(list);

            return list;
        }

        private void Swap(List<int> list, int index1, int index2)
        {
            int temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            AddToLog(list, $"Swapped {list[index1]} and {list[index2]}");
        }
    }
}
