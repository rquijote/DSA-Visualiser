using Backend.Classes;

namespace AlgorithmTests;

[TestClass]
public class BreadthFirstSearchTest
{
    BreadthFirstSearch bfs = new BreadthFirstSearch();

    [TestMethod]
    public void BFS_Traverses_Basic_Graph()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {1, new List<int> { 2, 3 } },
            {2, new List<int> { 4 } },
            {3, new List<int> { 5 } },
            {4, new List<int>() },
            {5, new List<int>() },
        };

        List<int> result = bfs.Traverse(graph, 1);
        List<int> expected = [ 1, 2, 3, 4, 5 ];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void BFS_Wont_Repeat_Visited_Nodes()
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

        List<int> result = bfs.Traverse(graph, 1);
        List<int> expected = [1, 2, 4, 3, 5, 6];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void BFS_Handles_Single_Node()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {1, new List<int> { } }
        };

        List<int> result = bfs.Traverse(graph, 1);
        List<int> expected = [1];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void BFS_Handles_Disconnected_Graphs()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {1, new List<int> { 2 } },
            {2, new List<int>() },
            {3, new List<int> { 4 } },
            {4, new List<int>() }
        };

        List<int> result = bfs.Traverse(graph, 1);
        List<int> expected = [1, 2];
        CollectionAssert.AreEqual(expected, result);
    }

    [TestMethod]
    public void BFS_Handles_No_Starting_Node()
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        List<int> result = bfs.Traverse(graph, 1);
        List<int> expected = [];
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void BFS_Returns_Log()
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

        List<int> result = bfs.Traverse(graph, 1);
        List<Log> logList = bfs.GetLog();
        Assert.IsNotNull(logList);
        Assert.AreNotEqual(0, logList.Count);
    }
}
