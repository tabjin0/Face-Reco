using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wavRecording.pojo;

namespace wavRecording.utils.response {
    public class PackageResponse {
        /// <summary>
        /// 包装返回的对象
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="description">描述</param>
        /// <param name="extendAttribute">拓展属性</param>
        /// <returns></returns>
        public static AddFileASRTaskResponse Response(int status, string description, ExtendAttribute extendAttribute) {
            AddFileASRTaskResponse response = new AddFileASRTaskResponse();
            CommonResponseType type = new CommonResponseType();
            type.Status = status;
            type.Description = description;
            response.CommonResponse = type;
            response.ExtendAttribute = extendAttribute;
            return response;
        }
    }
}
