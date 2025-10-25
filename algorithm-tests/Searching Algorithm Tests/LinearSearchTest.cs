using Backend.Classes;
namespace AlgorithmTests;

[TestClass]
public class LinearSearchTest
{
    LinearSearch linearSearch = new LinearSearch();

    [TestMethod]
    public void Linear_Search_Finds_Element_Index()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        int result = linearSearch.Search(list, 30); // Returns index
        Assert.AreEqual(8, result); // 8th index
    }

    [TestMethod]
    public void Linear_Search_Correct_Iterations_If_Found()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        linearSearch.Search(list, 28);
        int result = linearSearch.GetIterations();
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void Linear_Search_Correct_Iterations_If_Not_Found()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        linearSearch.Search(list, 95);
        int result = linearSearch.GetIterations();
        Assert.AreEqual(16, result);
    }

    [TestMethod]
    public void Linear_Search_Finds_No_Element_If_Missing()
    {
        List<int> list = new() { };
        int result = linearSearch.Search(list, 30);
        Assert.AreEqual(-1, result);
    }

    [TestMethod]
    public void Linear_Search_Returns_Not_Found_On_Empty_Data()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        int result = linearSearch.Search(list, 3);
        Assert.AreEqual(-1, result);
    }

    [TestMethod]
    public void Linear_Search_Finds_On_Singular_Index()
    {
        List<int> list = new List<int> { 2 };
        int index = linearSearch.Search(list, 2);
        int iterations = linearSearch.GetIterations();
        Assert.AreEqual(0, index);
        Assert.AreEqual(1, iterations);
    }

    [TestMethod]
    public void Linear_Search_Returns_Log()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 58, 59, 72, 75, 91, 93 };
        linearSearch.Search(list, 75);
        List<Log> logList = linearSearch.GetLog();
        Assert.IsNotNull(logList);
        Assert.AreNotEqual(0, logList.Count);
    }
}
