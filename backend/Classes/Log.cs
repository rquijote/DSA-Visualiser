using System.Reflection.Metadata.Ecma335;

namespace Backend.Classes
{
    public class Log(List<int> list, string msg)
    {
        public readonly List<int> _list = list;
        public readonly string _msg = msg;

        public string GetMsg()
        {
            return _msg;
    }
    }
}
