using System.Text.Json;
using Backend;

namespace AlgorithmTests
{
    [TestClass]
    public sealed class BubbleSortTest
    {

        [TestMethod]
        public void Correct_Result()
        {
            BubbleSort.Sort(new List<int> { 6, 3, 8, 9, 2 });
            List<int> result = BubbleSort.GetList();
            List<int> expected = [2, 3, 6, 8, 9];
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Correct_Operations()
        {
            int expected = 20;
            BubbleSort.Sort(new List<int> { 6, 3, 8, 9, 2 });
            int result = BubbleSort.GetOpCount();
            Assert.AreEqual(expected, result);
        }

        /* Fix this 
        [TestMethod]
        public void Controller_Returns_Expected_Log_Json()
        {
            var controller = new BubbleSortController();
            int[] input = [6, 3, 8, 9, 2];

            var expectedLog = new List<object>
            {
                new { Data = List<int> { 3, 6, 8, 9, 2 }, Msg = "Swapped 6 and 3" },
                new { Data = List<int> { 3, 6, 8, 9, 2 }, Msg = "No swap needed for 6 and 8" },
                new { Data = List<int> { 3, 6, 8, 9, 2 }, Msg = "No swap needed for 8 and 9" },
                new { Data = List<int> { 3, 6, 8, 2, 9 }, Msg = "Swapped 9 and 2" },
                new { Data = List<int> { 3, 6, 2, 8, 9 }, Msg = "Swapped 8 and 2" },
                new { Data = List<int> { 3, 2, 6, 8, 9 }, Msg = "Swapped 6 and 2" },
                new { Data = List<int> { 2, 3, 6, 8, 9 }, Msg = "Swapped 3 and 2" }
            };

            var result = controller.SortArray(input);

            var options = new JsonSerializerOptions { WriteIndented = false };
            string expectedJson = JsonSerializer.Serialize(expectedLog, options);
            string resultJson = JsonSerializer.Serialize(result.Log, options);

            Assert.AreEqual(expectedJson, resultJson);
        }
        */

        [TestMethod]
        public void Reset_Clears_BubbleSort()
        {
            BubbleSort.Reset();
            int result = BubbleSort.GetOpCount();
            Assert.AreEqual(0, result);
            List<int> result2 = BubbleSort.GetList();
            CollectionAssert.AreEqual(new List<int>(), result2);
        }

        // Add edge cases here
    }
}
