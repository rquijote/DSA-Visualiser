using Backend.Classes;

namespace AlgorithmTests;

[TestClass]
public class QuickSortTest
{
    QuickSort quickSort = new QuickSort();

    [TestMethod]
    public void Quick_Sort_Returns_Correct_Results()
    {
        List<int> input = new List<int> { 6, 3, 8, 9, 2 };
        List<int> expected = [2, 3, 6, 8, 9];
        List<int> result = quickSort.Sort(input);
        CollectionAssert.AreEqual(result, expected);
    }

    [TestMethod]
    public void Quick_Sort_Returns_Correct_Results_2()
    {
        List<int> input = new List<int> { 7, 2, 5, 9 };
        List<int> expected = [2, 5, 7, 9];
        List<int> result = quickSort.Sort(input);
        CollectionAssert.AreEqual(result, expected);
    }

    [TestMethod]
    public void Quick_Sort_Returns_Correct_Results_3()
    {
        List<int> input = new List<int> { 0, 0, 8, 9 };
        List<int> expected = [0, 0, 8, 9];
        List<int> result = quickSort.Sort(input);
        CollectionAssert.AreEqual(result, expected);
    }

    [TestMethod]
    public void Quick_Sort_Reset_Returns_Empty_Values()
    {
        List<int> input = new List<int> { 6, 3, 8, 9, 2 };
        quickSort.Sort(input);
        quickSort.Reset();
        List<Log> result = quickSort.GetLog();
        List<Log> expected = [];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Quick_Sort_Returns_Log()
    {
        List<int> input = new List<int> { 6, 3, 8, 9, 2 };
        quickSort.Sort(input);
        List<Log> logList = quickSort.GetLog();
        Assert.IsNotNull(logList);
        Assert.AreNotEqual(0, logList.Count);
    }
}
