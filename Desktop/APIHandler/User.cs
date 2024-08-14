using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHandler {
    public class User {
        private string _id;
        public string _ID {
            get => this._id;
            set => this._id = value;
        }

        private string username;
        public string Username {
            get => this.username;
            set => this.username = value;
        }

        private string firstname;
        public string FirstName {
            get => this.firstname;
            set => this.firstname = value;
        }

        private string lastname;
        public string LastName {
            get => this.lastname;
            set => this.lastname = value;
        }

        private string password;
        public string Password {
            get => this.password;
            set => this.password = value;
        }

        private bool isadmin;
        public bool IsAdmin {
            get => this.isadmin;
            set => this.isadmin = value;
        }

        private string imageurl;
        public string ImageUrl {
            get => this.imageurl;
            set => this.imageurl = value;
        }
        public User(string _id, string username, string firstname, string lastname, string password, bool isadmin, string imageurl) {
            this._id = _id;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
            this.isadmin = isadmin;
            this.imageurl = imageurl;
        }
    }
}

/*
         private string _id;
        public string _ID {
            get => this._id;
            set => this._id = value;
        }

        private string username;
        public string Username {
            get => this.username;
            set => this.username = value;
        }

        private string firstname;
        public string FirstName {
            get => this.firstname;
            set => this.firstname = value;
        }

        private string lastname;
        public string LastName {
            get => this.lastname;
            set => this.lastname = value;
        }

        private string password;
        public string Password {
            get => this.password; 
            set => this.password = value;
        }

        private bool isadmin;
        public bool IsAdmin {
            get => this.isadmin;
            set => this.isadmin = value;
        }

        public User(string _id, string username, string firstname, string lastname, string password, bool isadmin) {
            this._id = _id;
            this.username = username;
            this.firstname = firstname;
            this.lastname = lastname;
            this.password = password;
            this.isadmin = isadmin;
        }
 */