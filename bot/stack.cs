using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anime_stack
{
    public class stack
    {
        public int _number=0;
        
        public string[] _anime_links = new string[1000];
        public string anime_links
        {
            get
            {
                try
                {
                    return _anime_links[_number--];
                }
                catch(Exception)
                {
                    return "error1";
                }
            }
            set { _number++; _anime_links[_number] = value;  }
        }
        public void restart()
        {
            for (int i = 1; i < _anime_links.Length; i++)
                if (_anime_links[i] == null)
                {
                    _number = i-1;
                    return;

                }
        }
    }
}
