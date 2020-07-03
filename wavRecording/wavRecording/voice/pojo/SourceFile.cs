using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wavRecording.pojo {
    public class SourceFile {
        /// <summary>
        /// 文件类型，1、音频文件，2、视音频合一文件
        /// </summary>
        private static int fileType = 1;

        public int FileType {
            get { return fileType; }
            set { fileType = value; }
        }

        /// <summary>
        /// 物理文件名称，不包含路径信息
        /// </summary>
        private static string fileName;

        public string FileName {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        /// 存储路径信息，可以是X:\test或者\\100.0.0.1\test或者ftp://user:pass@server:port/test
        /// </summary>
        private static string pathInfo;

        public string PathInfo {
            get { return pathInfo; }
            set { pathInfo = value; }
        }

        /// <summary>
        /// 文件入点，对于视频单位是帧，音频单位是采样点，当需要对源文件的一部分做语音识别时填写
        /// </summary>
        private long markIn;

        public long MarkIn {
            get { return markIn; }
            set { markIn = value; }
        }

        /// <summary>
        /// 文件出点，对于视频单位是帧，音频单位是采样点，当需要对源文件的一部分做语音识别时填写
        /// </summary>
        private long markOut;

        public long MarkOut {
            get { return markOut; }
            set { markOut = value; }
        }

        /// <summary>
        /// 开始时间，格式为 hh:mm:ss:ms
        /// </summary>
        private string startTime;

        public string StartTime {
            get { return startTime; }
            set { startTime = value; }
        }

        /// <summary>
        /// 结束时间，格式为 hh:mm:ss:ms
        /// </summary>
        private string endTime;

        public string EndTime {
            get { return endTime; }
            set { endTime = value; }
        }

        /// <summary>
        /// 源音频文件的声道开始序号，是指在目标所有声道中的序号，从0开始，可能大于0
        /// </summary>
        private int channelIndex;

        public int ChannelIndex {
            get { return channelIndex; }
            set { channelIndex = value; }
        }

        private ExtendAttribute extendAttribute;

        public ExtendAttribute ExtendAttribute {
            get { return extendAttribute; }
            set { extendAttribute = value; }
        }
    }
}
