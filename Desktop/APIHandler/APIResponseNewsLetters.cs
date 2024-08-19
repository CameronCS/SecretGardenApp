using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHandler {
    public class APIResponseNewsLetters {
        private int code;
        public int Code {
            get => this.code;
            set => this.code = value;
        }

        private List<NewsLetter> newsletters;
        public List<NewsLetter> Newsletters {
            get => this.newsletters;
            set => this.newsletters = value;
        }

        private string message;
        public string Message {
            get => this.message;
            set => this.message = value;
        }
    }
}
