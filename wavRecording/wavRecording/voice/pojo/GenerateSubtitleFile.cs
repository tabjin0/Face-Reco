using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wavRecording.pojo {
    public class GenerateSubtitleFile {
        /// <summary>
        /// 是否生成字幕文件(0:不支持；1：支持)，默认是0，即不支持。
        /// </summary>
        private int isGenerateSubtitleFile;

        /// <summary>
        /// 字幕文件信息
        /// </summary>
        private FileInfo fileInfo;

        public int IsGenerateSubtitleFile {
            get { return isGenerateSubtitleFile; }
            set { isGenerateSubtitleFile = value; }
        }
        public FileInfo FileInfo {
            get { return fileInfo; }
            set { fileInfo = value; }
        }
    }
}
