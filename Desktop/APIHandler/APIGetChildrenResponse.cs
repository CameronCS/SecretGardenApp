using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHandler {
    public class APIGetChildrenResponse(int code, string message, List<Child> children) {
        private int code = code;
        public int Code {
            get => this.code;
            set => this.code = value;
        }

        private string message = message;
        public string Message {
            get => this.message;
            set => this.message = value;
        }

        private List<Child> children = children;
        public List<Child> Children {
            get => this.children;
            set => this.children = value;
        }
    }
}
