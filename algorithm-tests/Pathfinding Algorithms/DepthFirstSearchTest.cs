using Backend.Classes;

namespace AlgorithmTests;

[TestClass]
public class DepthFirstSearchTest
{
    DepthFirstSearch dfs = new DepthFirstSearch();

    [TestMethod]
    public void DFS_Traverses_Basic_Graph()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {1, new List<int> { 2, 3 } },
            {2, new List<int> { 4 } },
            {3, new List<int> { 5 } },
            {4, new List<int>() },
            {5, new List<int>() },
        };

        List<int> result = dfs.Traverse(graph, 1);
        List<int> expected = [1, 3, 5, 2, 4];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void DFS_Wont_Repeat_Visited_Nodes()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {1, new List<int> { 2, 4 } },
            {2, new List<int> { 3, 5 } },
            {3, new List<int> { 6 } },
            {4, new List<int>() { 5 } },
            {5, new List<int>() },
            {6, new List<int>() { 1 } },
        };

        List<int> result = dfs.Traverse(graph, 1);
        List<int> expected = [1, 4, 5, 2, 3, 6];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void DFS_Handles_Single_Node()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {1, new List<int> { } }
        };

        List<int> result = dfs.Traverse(graph, 1);
        List<int> expected = [1];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void DFS_Handles_Disconnected_Graphs()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {1, new List<int> { 2 } },
            {2, new List<int>() },
            {3, new List<int> { 4 } },
            {4, new List<int>() }
        };

        List<int> result = dfs.Traverse(graph, 1);
        List<int> expected = [1, 2];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void DFS_Handles_No_Starting_Node()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        List<int> result = dfs.Traverse(graph, 1);
        List<int> expected = [];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void DFS_Returns_Log()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {1, new List<int> { 2, 4 } },
            {2, new List<int> { 3, 5 } },
            {3, new List<int> { 6 } },
            {4, new List<int>() { 5 } },
            {5, new List<int>() },
            {6, new List<int>() { 1 } },
        };

        List<int> result = dfs.Traverse(graph, 1);
        List<Log> logList = dfs.GetLog();
        Assert.IsNotNull(logList);
        Assert.AreNotEqual(0, logList.Count);
    }
}
