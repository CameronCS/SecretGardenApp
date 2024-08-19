using APIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretGardenDesktopApp {
    partial class UserWindow {
        private User user;
        private List<Child> children = [];
        private APIController controller;
        private List<NewsLetter> newsLetters = [];
    }
}
