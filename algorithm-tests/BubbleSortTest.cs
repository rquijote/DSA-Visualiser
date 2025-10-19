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
            BubbleSort.Sort([6, 3, 8, 9, 2]);
            int[] result = BubbleSort.Array();
            int[] expected = [2, 3, 6, 8, 9];
            Assert.AreEqual(expected, result);
        }

        public void Correct_Operations()
        {
            int expected = 15;
            int result = BubbleSort.OperationsCount();
            Assert.AreEqual(expected, result);
        }

        public void Controller_Returns_Expected_Log_Json()
        {
            var controller = new BubbleSortController();
            int[] input = [6, 3, 8, 9, 2];

            var expectedLog = new List<object>
            {
                new { Data = new int[] { 3, 6, 8, 9, 2 }, Msg = "Swapped 6 and 3" },
                new { Data = new int[] { 3, 6, 8, 9, 2 }, Msg = "No swap needed for 6 and 8" },
                new { Data = new int[] { 3, 6, 8, 9, 2 }, Msg = "No swap needed for 8 and 9" },
                new { Data = new int[] { 3, 6, 8, 2, 9 }, Msg = "Swapped 9 and 2" },
                new { Data = new int[] { 3, 6, 2, 8, 9 }, Msg = "Swapped 8 and 2" },
                new { Data = new int[] { 3, 2, 6, 8, 9 }, Msg = "Swapped 6 and 2" },
                new { Data = new int[] { 2, 3, 6, 8, 9 }, Msg = "Swapped 3 and 2" }
            };

            var result = controller.SortArray(input);

            var options = new JsonSerializerOptions { WriteIndented = false };
            string expectedJson = JsonSerializer.Serialize(expectedLog, options);
            string resultJson = JsonSerializer.Serialize(result.Log, options);

            Assert.AreEqual(expectedJson, resultJson);
        }

        public void Reset_Clears_BubbleSort()
        {
            BubbleSort.Reset();
            int result = BubbleSort.OperationsCount();
            Assert.AreEqual(0, result);
            int[] result2 = BubbleSort.Array();
            Assert.AreEqual([], result2);
        }
    }
}
