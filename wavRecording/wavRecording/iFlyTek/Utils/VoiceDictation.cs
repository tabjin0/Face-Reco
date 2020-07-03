//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Net;
//using System.Security.Cryptography;
//using System.Collections;
//using Newtonsoft.Json;
//using NAudio.Wave;
//using System.Net.WebSockets;
//using System.Threading;
//using Newtonsoft.Json.Linq;
////using Newtonsoft.Json.Linq.JObject;
//using wavRecording.iFlyTek.Pojo;

//namespace wavRecording.Tab_Utils
//{
//    class VoiceDictation
//    {
//        const int StatusFirstFrame = 0;
//        const int StatusContinueFrame = 1;
//        const int StatusLastFrame = 2;

//        static ClientWebSocket webSocket0;
//        static CancellationToken cancellation;
//        // 应用APPID（必须为webapi类型应用，并开通语音听写服务，参考帖子如何创建一个webapi应用：http://bbs.xfyun.cn/forum.php?mod=viewthread&tid=36481）
//        const string x_appid = "5df97d67";
//        // 接口密钥（webapi类型应用开通听写服务后，控制台--我的应用---语音听写---相应服务的apikey）
//        const string api_key = "d127110f214658ebc6a9a4d08d266437";
//        // 接口密钥（webapi类型应用开通听写服务后，控制台--我的应用---语音听写---相应服务的apisecret）
//        const string api_secret = "ae7e417e884dc8e725e158cc895cca25";
//        // 音频文件地址,示例音频请在听写接口文档底部下载
//        static string path = @"C:\Users\tabjin\Desktop\tabjinAudio\WaveInEvent 8kHz mono 637131266132977210.wav";//测试文件路径,自己修改

//        static string hostUrl = "https://ws-api.xfyun.cn/v2/iat";

//        async public static void Tasker()
//        {
//            var AudioData = File.ReadAllBytes(path);
//            Console.WriteLine("文件长度" + AudioData.Length);
//            // 构建鉴权url
//            string authUrl = GetAuthUrl();
//            string url = authUrl.Replace("http://", "ws://").Replace("https://", "wss://");
//            using (webSocket0 = new ClientWebSocket())
//            {
//                try
//                {
//                    await webSocket0.ConnectAsync(new Uri(url), cancellation);
//                    byte[] ReceiveBuff = new byte[1024];//根据实际情况设置大小
//                    var receive = webSocket0.ReceiveAsync(new ArraySegment<byte>(ReceiveBuff), cancellation);
//                    //连接成功，开始发送数据
//                    int frameSize = 122 * 8; //每一帧音频的大小,建议每 40ms 发送 122B
//                    int intervel = 10;
//                    int status = 0;  // 音频的状态

//                    byte[] buffer /*= new byte[frameSize]*/;
//                    // 发送音频
//                    for (int i = 0; i < AudioData.Length; i += frameSize)
//                    {
//                        buffer = SubArray(AudioData, i, frameSize);
//                        if (buffer == null)
//                        {
//                            status = StatusLastFrame;  //文件读完，改变status 为 2
//                        }
//                        switch (status)
//                        {
//                            case StatusFirstFrame:   // 第一帧音频status = 0
//                                JObject frame = new JObject();
//                                JObject business = new JObject();  //第一帧必须发送
//                                JObject common = new JObject();  //第一帧必须发送
//                                JObject data = new JObject();  //每一帧都要发送                            
//                                                               // 填充common
//                                common.Add("app_id", x_appid);
//                                //填充business                              
//                                business.Add("language", "zh_cn");
//                                business.Add("domain", "iat");
//                                business.Add("accent", "mandarin");
//                                //business.Add("nunum", 0);
//                                //business.Add("ptt", 0);//标点符号
//                                //business.Add("rlang", "zh-hk"); // zh-cn :简体中文（默认值）zh-hk :繁体香港(若未授权不生效)
//                                //business.Add("vinfo", 1);
//                                //business.Add("dwa", "wpgs");//动态修正(若未授权不生效)
//                                //business.Add("nbest", 5);// 句子多候选(若未授权不生效)
//                                //business.Add("wbest", 3);// 词级多候选(若未授权不生效)
//                                //填充data
//                                data.Add("status", StatusFirstFrame);
//                                data.Add("format", "audio/L16;rate=16000");
//                                data.Add("audio", Convert.ToBase64String(buffer));
//                                data.Add("encoding", "raw");
//                                //填充frame
//                                frame.Add("common", common);
//                                frame.Add("business", business);
//                                frame.Add("data", data);

//                                //Console.WriteLine(frame.ToString());
//                                var frameData = System.Text.Encoding.UTF8.GetBytes(frame.ToString());
//                                webSocket0.SendAsync(new ArraySegment<byte>(frameData), WebSocketMessageType.Text, true, cancellation);
//                                //webSocket.Send(JsonUtility.ToJson(frame));
//                                status = StatusContinueFrame;  // 发送完第一帧改变status 为 1
//                                break;
//                            case StatusContinueFrame:  //中间帧status = 1
//                                JObject frame1 = new JObject();
//                                JObject data1 = new JObject();  //每一帧都要发送                                                                                                                        
//                                //填充data
//                                data1.Add("status", StatusContinueFrame);
//                                data1.Add("format", "audio/L16;rate=16000");
//                                data1.Add("audio", Convert.ToBase64String(buffer));
//                                data1.Add("encoding", "raw");
//                                //填充frame
//                                frame1.Add("data", data1);

//                                var frameData1 = System.Text.Encoding.UTF8.GetBytes(frame1.ToString());
//                                webSocket0.SendAsync(new ArraySegment<byte>(frameData1), WebSocketMessageType.Text, true, cancellation);
//                                //webSocket.Send(JsonUtility.ToJson(frame1));
//                                break;
//                            case StatusLastFrame:    // 最后一帧音频status = 2 ，标志音频发送结束    
//                                break;
//                        }
//                        await Task.Delay(intervel); //模拟音频采样延时
//                    }
//                    #region 结束
//                    // Console.WriteLine("准备发送最后一段");
//                    JObject frame2 = new JObject();
//                    JObject data2 = new JObject();  //每一帧都要发送                                                                                                                        
//                                                    //填充data
//                    data2.Add("status", StatusLastFrame);
//                    //填充frame
//                    frame2.Add("data", data2);

//                    var frameData2 = System.Text.Encoding.UTF8.GetBytes(frame2.ToString());
//                    webSocket0.SendAsync(new ArraySegment<byte>(frameData2), WebSocketMessageType.Text, true, cancellation);
//                    // Console.WriteLine("发送最后一段结束");
//                    await Task.Delay(intervel);
//                    #endregion
//                    await receive;
//                    int reLength = receive.Result.Count;
//                    var reData = SubArray(ReceiveBuff, 0, reLength);

//                    var ReceviceStr = System.Text.Encoding.UTF8.GetString(reData);
//                    Console.WriteLine(ReceviceStr);
//                    var resultObj = GetResultData(ReceviceStr);
//                    Console.WriteLine("解析结果:" + resultObj.GetResultText());
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//            }
//        }
//        // 返回code为错误码时，请查询https://www.xfyun.cn/document/error-code解决方案
//        static string GetAuthUrl()
//        {
//            string date = DateTime.UtcNow.ToString("r");

//            Uri uri = new Uri(hostUrl);
//            StringBuilder builder = new StringBuilder("host: ").Append(uri.Host).Append("\n").//
//                                    Append("date: ").Append(date).Append("\n").//
//                                    Append("GET ").Append(uri.LocalPath).Append(" HTTP/1.1");

//            string sha = HMACsha256(api_secret, builder.ToString());
//            string authorization = string.Format("api_key=\"{0}\", algorithm=\"{1}\", headers=\"{2}\", signature=\"{3}\"", api_key, "hmac-sha256", "host date request-line", sha);
//            //System.Web.HttpUtility.UrlEncode

//            string NewUrl = "https://" + uri.Host + uri.LocalPath;

//            string path1 = "authorization" + "=" + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(authorization));
//            date = date.Replace(" ", "%20").Replace(":", "%3A").Replace(",", "%2C");
//            string path2 = "date" + "=" + date;
//            string path3 = "host" + "=" + uri.Host;

//            NewUrl = NewUrl + "?" + path1 + "&" + path2 + "&" + path3;
//            return NewUrl;
//        }

//        public static string HMACsha256(string apiSecretIsKey, string buider)
//        {
//            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(apiSecretIsKey);
//            System.Security.Cryptography.HMACSHA256 hMACSHA256 = new System.Security.Cryptography.HMACSHA256(bytes);
//            byte[] date = System.Text.Encoding.UTF8.GetBytes(buider);
//            date = hMACSHA256.ComputeHash(date);
//            hMACSHA256.Clear();

//            return Convert.ToBase64String(date);

//        }
//        /// <summary>
//        /// 从此实例检索子数组
//        /// </summary>
//        /// <param name="source">要检索的数组</param>
//        /// <param name="startIndex">起始索引号</param>
//        /// <param name="length">检索最大长度</param>
//        /// <returns>与此实例中在 startIndex 处开头、长度为 length 的子数组等效的一个数组</returns>
//        public static byte[] SubArray(byte[] source, int startIndex, int length)
//        {

//            if (startIndex < 0 || startIndex > source.Length || length < 0)
//            {
//                return null;
//            }
//            byte[] Destination;
//            if (startIndex + length <= source.Length)
//            {
//                Destination = new byte[length];
//                Array.Copy(source, startIndex, Destination, 0, length);
//            }
//            else
//            {
//                Destination = new byte[(source.Length - startIndex)];
//                Array.Copy(source, startIndex, Destination, 0, source.Length - startIndex);
//            }

//            return Destination;
//        }
//        static public ResponseData GetResultData(string ReceviceStr)
//        {
//            ResponseData temp = new ResponseData();
//            ReaponseDataInfo dataInfo = new ReaponseDataInfo();
//            ResponseResultInfo resultInfo = new ResponseResultInfo();
//            List<Ws> tempwsS;
//            List<Cw> tempcwS;

//            Ws tempWs;
//            Cw temocw;
//            var jsonObj = (JObject)JsonConvert.DeserializeObject(ReceviceStr);
//            //Debug.Log("1");
//            temp.Code = jsonObj["code"].ToObject<int>();
//            temp.Message = jsonObj["message"].ToObject<string>();
//            temp.Sid = jsonObj["sid"].ToObject<string>();
//            var data = jsonObj["data"]/*.ToObject<JObject>()*/;
//            //Debug.Log("2");
//            dataInfo.Status = data["status"].ToObject<int>();
//            var result = data["result"]/*.ToObject<JObject>()*/;
//            //Debug.Log("3");
//            resultInfo.Bg = result["bg"].ToObject<int>();
//            resultInfo.Ed = result["ed"].ToObject<int>();
//            //resultInfo.pgs = result["pgs"].ToObject<string>();
//            //resultInfo.rg = result["rg"].ToObject<int[]>(); 
//            resultInfo.Sn = result["sn"].ToObject<int>(); ;
//            resultInfo.Ls = result["ls"].ToObject<bool>(); ;
//            var wss = result["ws"];
//            //Debug.Log("4");
//            tempwsS = new List<Ws>();
//            JArray wsArray = wss.ToObject<JArray>();
//            //Debug.Log("5.0");
//            for (int i = 0; i < wsArray.Count; i++)
//            {
//                //Debug.Log("5.1");
//                tempWs = new Ws();
//                tempWs.Bg = wsArray[i]["bg"].ToObject<int>();
//                //Debug.Log("5.2");
//                //tempWs.ed = wsArray[i]["ed"].ToObject<int>();
//                var cws = wsArray[i]["cw"];
//                //Debug.Log("5.5");
//                tempcwS = new List<Cw>();
//                JArray cwArray = cws.ToObject<JArray>();
//                for (int j = 0; j < cwArray.Count; j++)
//                {
//                    temocw = new Cw();
//                    temocw.Sc = cwArray[j]["sc"].ToObject<int>();
//                    temocw.W = cwArray[j]["w"].ToObject<string>();
//                    tempcwS.Add(temocw);
//                }
//                tempWs.Cw = tempcwS.ToArray();
//                tempwsS.Add(tempWs);
//            }
//            //Debug.Log("6");
//            resultInfo.Ws = tempwsS.ToArray();
//            dataInfo.Result = resultInfo;
//            temp.Data = dataInfo;
//            return temp;
//            //int cod = jobj1.ToObject<int>();
//        }

//        //static void Main(string[] args)
//        //{
//        //    Tasker();
//        //    Console.ReadKey();
//        //}
//    }
//}

///// <summary>
///// 返回数据
///// </summary>

////public class ReaponseDataInfo
////{
////    public int status;
////    public ResponseResultInfo result;
////}
////public class ResponseResultInfo
////{
////    public int bg;
////    public int ed;
////    public string pgs;
////    public int[] rg;
////    public int sn;
////    public bool ls;
////    public Ws[] ws;
////}

////public class Ws
////{
////    public Cw[] cw;
////    public int bg;
////    public int ed;
////}
////public class Cw
////{
////    public int sc;
////    public string w;
////}

