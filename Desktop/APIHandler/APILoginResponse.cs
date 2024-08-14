using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHandler {
    public class APILoginResponse {
        private int code;
        public int Code {
            get => this.code;
            set => this.code = value;
        }

        private string message;
        public string Message {
            get => this.message;
            set => this.message = value;
        }

        private User user;
        public User User {
            get => this.user;
            set => this.user = value;
        }

        public APILoginResponse(int code, string message, User user) {
            this.code = code;
            this.message = message;
            this.user = user;
        }
    }
}
/*
     public class APILoginResponse {
        private int code;
        public int Code {
            get => this.code;
            set => this.code = value;
        }

        private string message;
        public string Message {
            get => this.message;
            set => this.message = value;
        }

        private User user;
        public User User {
            get => this.user;
            set => this.user = value;
        }

        public APILoginResponse(int code, string message,  User user) {
            this.code = code;
            this.message = message;
            this.user = user;
        }
    }
 */