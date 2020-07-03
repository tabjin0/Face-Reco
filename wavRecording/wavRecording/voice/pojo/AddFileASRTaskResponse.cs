using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wavRecording.pojo {
    public class AddFileASRTaskResponse {
        private CommonResponseType commonResponse;
        private ExtendAttribute extendAttribute;
        public CommonResponseType CommonResponse {
            get { return commonResponse; }
            set { commonResponse = value; }
        }

        public ExtendAttribute ExtendAttribute {
            get { return extendAttribute; }
            set { extendAttribute = value; }
        }
    }
}
