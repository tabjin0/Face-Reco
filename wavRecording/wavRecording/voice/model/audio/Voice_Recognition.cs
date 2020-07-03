using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wavRecording.config;
using wavRecording.model.audio;
using wavRecording.pojo;
using wavRecording.utils.http;
using wavRecording.utils.response;
using wavRecording.voice.utils;

namespace wavRecording.model.audio
{
    public class Voice_Recognition
    {
        public static AddFileASRTaskResponse postVoiceRecognitionXML(AddFileASRTaskRequest addFileASRTaskRequest)
        {
            string url = UrlConstant.VOICE_RECOGNITION_BASE_URL + "/LeoVideoAPI/service/addFileASRTask";
            string data = XMLHelper.XmlSerialize(addFileASRTaskRequest);
            string responseContent = Http.HttpPostXML(url, data);

            //return PackageResponse.Response();
            return null;
        }

        static string buildXML(AddFileASRTaskRequest addFileASRTaskRequest)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            sb.Append("<AddFileASRTaskRequest>");
            sb.AppendFormat("<UserID>{0}</UserID>", addFileASRTaskRequest.UserID);
            //sb.Append("</UserID>");
            sb.AppendFormat("<TaskID>{0}</TaskID>", addFileASRTaskRequest.TaskID);
            sb.AppendFormat("<CallBackAddressInfo>{0}</CallBackAddressInfo>", addFileASRTaskRequest.CallBackAddressInfo);
            sb.AppendFormat("<TaskName>{0}</TaskName>", addFileASRTaskRequest.TaskName);
            sb.AppendFormat("<Poiority>{0}/Poiority>", addFileASRTaskRequest.Poiority);
            sb.AppendFormat("<SourceFile>{0}</SourceFile>", addFileASRTaskRequest.SourceFile);
            sb.AppendFormat("<GenerateSubtitleFile>{0}</GenerateSubtitleFile>", addFileASRTaskRequest.GenerateSubtitleFile);
            sb.AppendFormat("<ResultIncludeTime>{0}</ResultIncludeTime>", addFileASRTaskRequest.ResultIncludeTime);
            sb.AppendFormat("<IncludePunctuation>{0}</IncludePunctuation>", addFileASRTaskRequest.IncludePunctuation);
            sb.AppendFormat("<Language>{0}</Language>", addFileASRTaskRequest.Language);
            sb.AppendFormat("<ExtendAttribute>{0}</ExtendAttribute>", addFileASRTaskRequest.ExtendAttribute);
            sb.Append("</AddFileASRTaskRequest>");
            return sb.ToString();
        }

        static string buildMultitaskSourceFileXML(List<SourceFile> sourceFileList)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<SourceFile>");
            if (sourceFileList.Count == 0)
            {
                return "";
            }
            else
            {
                foreach (SourceFile sourceFile in sourceFileList)
                {
                    sb.AppendFormat("<FileType>{0}</FileType>", sourceFile.FileType);
                    sb.AppendFormat("<FileName>{0}</FileName>", sourceFile.FileName);
                    sb.AppendFormat("<PathInfo>{0}</PathInfo>", sourceFile.PathInfo);
                }
            }
            sb.Append("<>");

            return null;
        }
    }
}
