using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHandler {
    public class Child {
        private string _id;
        public string _ID {
            get => this._id;
            set => this._id = value;
        }

        private string imagePath;
        public string ImagePath {
            get => this.imagePath;
            set => this.imagePath = value;
        }

        private string firstName;
        public string FirstName {
            get => this.firstName;
            set => this.firstName = value;
        }

        private string lastName;
        public string LastName {
            get => this.lastName;
            set => this.lastName = value;
        }

        private string className;
        public string ClassName {
            get => this.className;
            set => this.className = value;
        }

        private string parentID1;
        public string ParentID1 {
            get => this.parentID1; 
            set => this.parentID1 = value;
        }

        private string parentID2;
        public string ParentID2 {
            get => this.parentID2; 
            set => this.parentID2 = value;
        }
        public Child() {
        }
    }
}
