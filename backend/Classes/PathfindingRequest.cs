namespace Backend.Classes
{
    public class PathfindingRequest
    {
        public Dictionary<int, List<int>> Graph { get; set; }
        public int StartNode { get; set; }
        public int? TargetNode { get; set; }
    }
}
