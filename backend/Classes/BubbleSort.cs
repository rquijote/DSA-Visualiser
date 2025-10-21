namespace Backend.Classes
{
    public class BubbleSort : SortingAlgorithm
    {
        public override List<int> Sort(List<int> listToSort)
        {
            for (int i = 0; i < listToSort.Count; i++)
            {
                for (int j = 1; j < listToSort.Count; j++)
                {
                    IncrementOpCount();
                    if (listToSort[j] < listToSort[j - 1])
                    {
                        Swap(listToSort, j, j - 1);
                    }
                }
            }

            //Now bubble sorted list
            SetList(listToSort);

            return listToSort;
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
