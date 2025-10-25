using Backend.Classes;
namespace AlgorithmTests;

[TestClass]
public class BinarySearchTest
{
    BinarySearch binarySearch = new BinarySearch();

    [TestMethod]
    public void Binary_Search_Finds_Element_Index()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 56, 59, 72, 75, 91, 93 };
        int result = binarySearch.Search(list, 30); // Returns index
        Assert.AreEqual(8, result); // 8th index
    }

    [TestMethod]
    public void Binary_Search_Finds_Element_In_Correct_Iterations()
    {
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 56, 59, 72, 75, 91, 93 };
        binarySearch.Search(list, 91);
        int result = binarySearch.getIterations();
        Assert.AreEqual(4, result);
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
        List<int> list = new List<int> { 2, 5, 6, 11, 12, 17, 24, 28, 30, 56, 56, 59, 72, 75, 91, 93 };
        int result = binarySearch.Search(list, 3);
        Assert.AreEqual(-1, result);
    }

    [TestMethod]
    public void Binary_Search_Finds_On_Singular_Index()
    {
        List<int> list = new List<int> { 2 };
        int result = binarySearch.Search(list, 2);
        Assert.AreEqual(0, result);
    }
}
