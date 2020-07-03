using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wavRecording.iFlyTek.Pojo
{
    public class ReaponseDataInfo
    {
        private int status;
        private ResponseResultInfo result;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public ResponseResultInfo Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
