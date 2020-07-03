using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wavRecording.pojo {
    public class FileInfo {
        /// <summary>
        /// 字幕文件名称
        /// </summary>
        private string fileName;

        /// <summary>
        /// 字幕文件路径
        /// </summary>
        private string filePath;

        /// <summary>
        /// 字幕文件类型，可以是srt或者vtt，如果不填，默认是srt
        /// </summary>
        private string subtitleFileType;

        public string FilePath {
            get { return filePath; }
            set { filePath = value; }
        }
        public string FileName {
            get { return fileName; }
            set { fileName = value; }
        }
        public string SubtitleFileType {
            get { return subtitleFileType; }
            set { subtitleFileType = value; }
        }
    }
}
