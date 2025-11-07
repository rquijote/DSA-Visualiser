namespace Backend.Classes
{
    public class Log
    {
        public List<int> List { get; set; }
        public string Msg { get; set; }
        public Dictionary<string, object> Extras { get; set; }

        public Log(List<int> list, string msg, Dictionary<string, object> extras)
        {
            List = list;
            Msg = msg;
            Extras = extras ?? new Dictionary<string, object>();
        }
    }
}
