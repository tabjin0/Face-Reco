using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wavRecording.iFlyTek.Pojo
{
    /// <summary>
    /// 返回数据
    /// </summary>
    public class ResponseData
    {
        private int code;
        private string message;
        private string sid;
        private ReaponseDataInfo data;

        public string GetResultText()
        {
            var resultT = this.data.Result;
            var wsT = resultT.Ws;
            StringBuilder strB = new StringBuilder();
            for (int i = 0; i < wsT.Length; i++)
            {
                strB.Append(wsT[i].Cw[0].W);
            }
            return strB.ToString();
        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Sid
        {
            get { return sid; }
            set { sid = value; }
        }

        public ReaponseDataInfo Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
