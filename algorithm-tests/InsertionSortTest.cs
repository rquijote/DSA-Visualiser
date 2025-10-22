using Backend.Classes;

namespace AlgorithmTests;

[TestClass]
public class InsertionSortTest
{
    InsertionSort insertionSort = new InsertionSort();

    [TestMethod]
    public void Insertion_Sort_Returns_Correct_Results()
    {
        List<int> input = new List<int> { 6, 3, 8, 9, 2 };
        List<int> expected = [2, 3, 6, 8, 9];
        List<int> result = insertionSort.Sort(input);
        CollectionAssert.AreEqual(result, expected);
    }

    [TestMethod]
    public void Insertion_Sort_Returns_Correct_Results_2()
    {
        List<int> input = new List<int> { 7, 2, 5, 9 };
        List<int> expected = [2, 5, 7, 9];
        List<int> result = insertionSort.Sort(input);
        CollectionAssert.AreEqual(result, expected);
    }

    [TestMethod]
    public void Insertion_Sort_Returns_Correct_Results_3()
    {
        List<int> input = new List<int> { 0, 0, 8, 9 };
        List<int> expected = [0, 0, 8, 9];
        List<int> result = insertionSort.Sort(input);
        CollectionAssert.AreEqual(result, expected);
    }

    [TestMethod]
    public void Insertion_Sort_Reset_Returns_Empty_Values()
    {
        List<int> input = new List<int> { 6, 3, 8, 9, 2 };
        insertionSort.Sort(input);
        insertionSort.Reset();
        List<Log> result = insertionSort.GetLog();
        List<Log> expected = [];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Insertion_Sort_Returns_Log()
    {
        List<int> input = new List<int> { 6, 3, 8, 9, 2 };
        insertionSort.Sort(input);
        List<Log> logList = insertionSort.GetLog();
        Assert.IsNotNull(logList);
    }

    // Add edge cases here if needed
}
