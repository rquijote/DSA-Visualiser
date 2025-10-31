namespace Backend.Classes
{
    public class Log
    {
        public List<int> List { get; set; }
        public string Msg { get; set; }
        public List<int> Highlight { get; set; }

        public Log(List<int> list, string msg, List<int> highlight)
        {
            List = list;
            Msg = msg;
            Highlight = highlight;
        }
    }
}
