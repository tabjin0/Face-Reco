using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wavRecording.iFlyTek.Pojo
{
    public class ResponseResultInfo
    {
        private int bg;
        private int ed;
        private string pgs;
        private int[] rg;
        private int sn;
        private bool ls;
        private Ws[] ws;

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

        public string Pgs
        {
            get { return pgs; }
            set { pgs = value; }
        }

        public int[] Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        public int Sn
        {
            get { return sn; }
            set { sn = value; }
        }

        public bool Ls
        {
            get { return ls; }
            set { ls = value; }
        }

        public Ws[] Ws
        {
            get { return ws; }
            set { ws = value; }
        }
    }
}
