using System.Reflection.Metadata.Ecma335;

namespace Backend.Classes
{
    public class Log
    {
        public List<int> List { get; set; }
        public string Msg { get; set; }

        public Log(List<int> list, string msg)
        {
            List = list;
            Msg = msg;
        }
    }
}
