using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 文件语音识别任务
namespace wavRecording.pojo {
    public class AddFileASRTaskRequest {
        /// <summary>
        /// 提交任务的用户ID，或者是提交的系统的ID，比如DYEDIT，DYMAM等
        /// </summary>
        private string userID = "DYMAM";

        /// <summary>
        /// 任务的唯一标示，不可重复，建议使用GUID或者UUID
        /// </summary>
        private string taskID;

        /// <summary>
        /// 异步回调地址URL，任务执行完毕回调通知时使用本地址
        /// </summary>
        private string callBackAddressInfo;

        /// <summary>
        /// 任务名称
        /// </summary>
        private string taskName;

        /// <summary>
        /// 优先级，默认为0，数字越大优先级越高
        /// </summary>
        private int poiority;

        /// <summary>
        /// 源文件信息，语音识别可以支持多个声道的音频文件，也支持视音频合一的文件，但只支持一种识别内容；也就是说不支持类似一个音频文件是对白，另外一个音频文件是背景解说的情况
        /// </summary>
        private SourceFile sourceFile;
        
        /// <summary>
        /// 生成字幕文件信息。只有科大讯飞引擎的时候支持生成字幕文件，且只生成srt字幕文件。
        /// </summary>
        private GenerateSubtitleFile generateSubtitleFile;
        
        /// <summary>
        /// 识别结果是否带时码信息，0不带，1带。默认是1
        /// </summary>
        private int resultIncludeTime = 1;
        
        /// <summary>
        /// >带时码结果是否包含标点符号。只有ResultIncludeTime字段为1时生效。0，不包含标点；1，包含标点；默认1
        /// </summary>
        private int includePunctuation = 1;

        /// <summary>
        /// 语音语言类型：cn：普通话，hk；粤语；默认普通话cn
        /// </summary>
        private string language = "cn";

        private ExtendAttribute extendAttribute;
        public ExtendAttribute ExtendAttribute {
            get { return extendAttribute; }
            set { extendAttribute = value; }
        }
        public string Language {
            get { return language; }
            set { language = value; }
        }

        public int IncludePunctuation {
            get { return includePunctuation; }
            set { includePunctuation = value; }
        }
        public int ResultIncludeTime {
            get { return resultIncludeTime; }
            set { resultIncludeTime = value; }
        }
        public GenerateSubtitleFile GenerateSubtitleFile {
            get { return generateSubtitleFile; }
            set { generateSubtitleFile = value; }
        }
        public SourceFile SourceFile {
            get { return sourceFile; }
            set { sourceFile = value; }
        }
        public int Poiority {
            get { return poiority; }
            set { poiority = value; }
        }
        public string TaskName {
            get { return taskName; }
            set { taskName = value; }
        }
        public string CallBackAddressInfo {
            get { return callBackAddressInfo; }
            set { callBackAddressInfo = value; }
        }
        public string TaskID {
            get { return taskID; }
            set { taskID = value; }
        }

        public string UserID {
            get { return userID; }
            set { userID = value; }
        }

    }
}
