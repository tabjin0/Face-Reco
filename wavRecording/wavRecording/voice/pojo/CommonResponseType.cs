using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wavRecording.pojo {
    public class CommonResponseType {
        private int status;
        private string description;

        public int Status {
            get { return status; }
            set { status = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }

    }
}
