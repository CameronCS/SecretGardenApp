using APIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecretGardenDesktopApp {
    partial class UserWindow {
        private void LoadAllContent() {
            this.LoadChildren();
        }

        private async void LoadChildren() {
            APIGetChildrenResponse response = await this.controller.GetChildren("user/children", this.user._ID);

            switch (response.Code) {
                case 0: {
                    MessageBox.Show(this, "No Connect, Please check your connection, if this issue persists please inform us", "No Connection", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                }

                case 200: {
                    this.children = response.Children;
                    this.PBLoadIn.Value += 10;
                    break;
                }

                case 401: {
                    this.children = [];
                    this.PBLoadIn.Value += 10;
                    break;
                }

                case 500: {
                    MessageBox.Show(this, "Internal Server Error, Application Closing", "Internal Server Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Close();
                    break;
                }
            }
        }

        private async void LoadNewsLetters() {
            foreach (Child c in this.children) {
                APIResponseNewsLetters response = await this.controller.GetNewsLetters("user", c.ClassID);
                switch (response.Code) {
                    case 0: {
                        MessageBox.Show(this, "No Connect, Please check your connection, if this issue persists please inform us", "No Connection", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                    }

                    case 200: {
                        foreach (NewsLetter letter in response.Newsletters) {
                            this.newsLetters.Add(letter);
                        }
                        break;
                    }

                    case 500: {
                        MessageBox.Show(this, "Internal Server Error, Application Closing", "Internal Server Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.Close();
                        break;
                    }
                }
            }
            this.PBLoadIn.Value += 10;
        }
    }
}
