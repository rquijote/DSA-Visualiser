using Backend.Classes;

namespace AlgorithmTests
{
    [TestClass]
    public sealed class BubbleSortTest
    {
        BubbleSort bubbleSort = new BubbleSort();

        [TestMethod]
        public void Bubble_Sort_Returns_Correct_Results()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            List<int> expected = [2, 3, 6, 8, 9];
            List<int> result = bubbleSort.Sort(input);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Bubble_Sort_Returns_Correct_Results_2()
        {
            List<int> input = new List<int> { 7, 2, 5, 9 };
            List<int> expected = [2, 5, 7, 9];
            List<int> result = bubbleSort.Sort(input);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Bubble_Sort_Returns_Correct_Results_3()
        {
            List<int> input = new List<int> { 0, 0, 8, 9 };
            List<int> expected = [0, 0, 8, 9];
            List<int> result = bubbleSort.Sort(input);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Bubble_Sort_Reset_Returns_Empty_Values()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            bubbleSort.Sort(input);
            bubbleSort.Reset();
            List<Log> result = bubbleSort.GetLog();
            List<Log> expected = [];
            CollectionAssert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void Bubble_Sort_Returns_Log()
        {
            List<int> input = new List<int> { 6, 3, 8, 9, 2 };
            bubbleSort.Sort(input);
            List<Log> logList = bubbleSort.GetLog();
            Assert.IsNotNull(logList);
            Assert.AreNotEqual(0, logList.Count);
        }
    }
}
