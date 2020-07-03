using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wavRecording.pojo {
    public class ExtendAttribute {
        private string atttibuteID;
        private string attributeValue;

        public string AtttibuteID {
            get { return atttibuteID; }
            set { atttibuteID = value; }
        }
        public string AttributeValue {
            get { return attributeValue; }
            set { attributeValue = value; }
        }
    }
}
