using System.Text.Json;
using Backend.Classes;

namespace AlgorithmTests
{
    [TestClass]
    public sealed class BubbleSortTest
    {
        BubbleSort bubbleSort = new BubbleSort();

        [TestMethod]
        public void Bubble_Sort_Returns_Correct_Result()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            List<int> expected = [2, 3, 6, 8, 9];
            List<int> result = bubbleSort.Sort(input);
            CollectionAssert.AreEqual(result, expected);
        }
  
        [TestMethod]
        public void Bubble_Sort_Returns_Correct_Operations()
        {
            int expectedOpCount = 20;
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            bubbleSort.Sort(input);
            int result = bubbleSort.GetOpCount();
            Assert.AreEqual(expectedOpCount, result);
        }

        [TestMethod]
        public void Reset_Clears_All_Sorts()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            bubbleSort.Sort(input);
            bubbleSort.Reset();
            int result = bubbleSort.GetOpCount();
            Assert.AreEqual(0, result);
        }
        
        [TestMethod]
        public void Sorts_Returns_Log()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            bubbleSort.Sort(input);
            List<Log> logList = bubbleSort.GetLog();
            Assert.IsNotNull(logList);
        }

        // Add edge cases here if needed
    }
}
