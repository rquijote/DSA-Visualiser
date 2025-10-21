using System.Text.Json;
using Backend.Classes;

namespace AlgorithmTests
{
    [TestClass]
    public sealed class SortingTests
    {
        // All sorting functions
        List<Func<List<int>, List<int>>> sortingFunctions = new List<Func<List<int>, List<int>>>() 
        { 
            BubbleSort.Sort
            //Add other sorts here
        };

        // All get operation count functions
        List<Func<int>> getOpCountFunctions = new List<Func<int>>() 
        { 
            BubbleSort.GetOpCount 
             //Add other sorts here
        };

        // Reset functions
        List<Action> resetFunctions = new List<Action>()
        {
            BubbleSort.Reset
            //Add other sorts here
        };

        List<Func<List<Log>>> getLogFunctions = new List<Func<List<Log>>>()
        {
            BubbleSort.GetLog
            //Add other sorts here
        };

        [TestMethod]
        public void All_Sorting_Returns_Correct_Result()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            List<int> expected = [2, 3, 6, 8, 9];
            foreach (Func<List<int>, List<int>> func in sortingFunctions)
            {
                List<int> result = func(input);
                CollectionAssert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void Sort_Returns_Correct_Operations()
        {
            // Expected operation counts 
            int[] expectedOpCount = [20];
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            foreach (Func<List<int>, List<int>> sorts in sortingFunctions)
            {
                sorts(input);
            }
            int i = 0;
            foreach (Func<int> getOps in getOpCountFunctions)
            {
                int result = getOps();
                Assert.AreEqual(expectedOpCount[i], result);
                i++;
            }
        }

        [TestMethod]
        public void Reset_Clears_All_Sorts()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            List<int> expected = [2, 3, 6, 8, 9];
            foreach (Func<List<int>, List<int>> sorts in sortingFunctions)
            {
                sorts(input);
            }
            foreach (Action resets in resetFunctions)
            {
                resets();
            }
            foreach (Func<int> getOps in getOpCountFunctions)
            {
                int result = getOps();
                Assert.AreEqual(0, result);
            }
            /* Add other get lists here */
            List<int> result2 = BubbleSort.GetList();
            CollectionAssert.AreEqual(new List<int>(), result2);
        }

        [TestMethod]
        public void Sorts_Returns_Log()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            foreach (Func<List<int>, List<int>> sorts in sortingFunctions)
            {
                sorts(input);
            }
            foreach (Func<List<Log>> logFunctions in getLogFunctions)
            {
                List<Log> result = BubbleSort.GetLog();
                Assert.IsNotNull(result);
            }
        }

        // Add edge cases here
    }
}
