using Backend.Classes;
namespace AlgorithmTests;

[TestClass]
public class BinarySearchTest
{
    BinarySearch binarySearch = new BinarySearch();

    [TestMethod]
    public void Binary_Search_Finds_Element_Index()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        int result = binarySearch.Search(list, 30); // Returns index
        Assert.AreEqual(8, result); // 8th index
    }

    [TestMethod]
    public void Binary_Search_Correct_Iterations_If_Found()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        binarySearch.Search(list, 17);
        int result = binarySearch.GetIterations();
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Binary_Search_Correct_Iterations_If_Not_Found()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        binarySearch.Search(list, 95);
        int result = binarySearch.GetIterations();
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void Binary_Search_Finds_No_Element_If_Missing()
    {
        List<int> list = new() { };
        int result = binarySearch.Search(list, 30);
        Assert.AreEqual(-1, result);
    }

    [TestMethod]
    public void Binary_Search_Returns_Not_Found_On_Empty_Data()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        int result = binarySearch.Search(list, 3);
        Assert.AreEqual(-1, result);
    }

    [TestMethod]
    public void Binary_Search_Finds_On_Singular_Index()
    {
        List<int> list = new List<int> { 2 };
        int index = binarySearch.Search(list, 2);
        int iterations = binarySearch.GetIterations();
        Assert.AreEqual(0, index);
        Assert.AreEqual(1, iterations);
    }

    [TestMethod]
    public void Binary_Search_Returns_Log_If_Found()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        binarySearch.Search(list, 75);
        List<Log> logList = binarySearch.GetLog();
        Assert.IsNotNull(logList);
        Assert.AreNotEqual(0, logList.Count);
    }

    [TestMethod]
    public void Binary_Search_Returns_Log_If_Not_Found()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        binarySearch.Search(list, 44);
        List<Log> logList = binarySearch.GetLog();
        Assert.IsNotNull(logList);
        Assert.AreNotEqual(0, logList.Count);
    }
}
