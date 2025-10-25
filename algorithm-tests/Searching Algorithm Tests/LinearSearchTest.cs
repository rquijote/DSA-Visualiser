using Backend.Classes;
namespace AlgorithmTests;

[TestClass]
public class LinearSearchTest
{
    LinearSearch linearSearch = new LinearSearch();

    [TestMethod]
    public void Linear_Search_Finds_Element_Index()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 56, 59, 72, 75, 91, 93 };
        int result = linearSearch.Search(list, 30); // Returns index
        Assert.AreEqual(8, result); // 8th index
    }

    [TestMethod]
    public void Linear_Search_Finds_Element_In_Correct_Iterations()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 56, 59, 72, 75, 91, 93 };
        linearSearch.Search(list, 91);
        int result = linearSearch.getIterations();
        Assert.AreEqual(8, result);
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
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 56, 59, 72, 75, 91, 93 };
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
}
