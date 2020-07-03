using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wavRecording.iFlyTek.Pojo
{
    public class Ws
    {
        private Cw[] cw;
        private int bg;
        private int ed;

        public Cw[] Cw
        {
            get { return cw; }
            set { cw = value; }
        }

        public int Bg
        {
            get { return bg; }
            set { bg = value; }
        }

        public int Ed
        {
            get { return ed; }
            set { ed = value; }
        }
    }
}
