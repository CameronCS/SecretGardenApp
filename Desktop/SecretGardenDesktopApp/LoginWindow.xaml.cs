// Necessary Using Statements
using System.Windows;
using System.Windows.Input;
using APIHandler;

// Main Application Namespace
namespace SecretGardenDesktopApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        // The URL Connecting the IP Address
        private readonly string APIUrl;
        // The API Controller from the Class Library
        private readonly APIController controller;
        /// <summary>
        /// Class Constructor
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            this.APIUrl = "http://192.168.0.187:3050";
            this.controller = new(this.APIUrl);
        }

        /// <summary>
        /// The Mouse Enter event to show a password
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Mouse Event Args</param>
        private void LblShowPassword_MouseEnter(object sender, MouseEventArgs e) {
            TBLoginPassword.Text       = PBLoginPassword.Password;
            PBLoginPassword.Visibility = Visibility.Collapsed;
            TBLoginPassword.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// The Mouse Leave event to show a password
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Mouse Event Args</param>
        private void LblShowPassword_MouseLeave(object sender, MouseEventArgs e) {
            PBLoginPassword.Password   = TBLoginPassword.Text;
            TBLoginPassword.Visibility = Visibility.Collapsed;
            PBLoginPassword.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Async Method For Logging In
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Routed Event Args</param>
        private async void BtnLogIn_Click(object sender, RoutedEventArgs e) {
            // Username has text check
            if (this.TBLoginUsername.Text.Trim() == string.Empty) {
                MessageBox.Show(this, "Please enter your username", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Password has text check
            if (this.PBLoginPassword.Password == string.Empty) {
                MessageBox.Show(this, "Please enter your password", this.Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Collecting the values
            string username = this.TBLoginUsername.Text;
            string password = this.PBLoginPassword.Password;

            // Setting the values into a dictionary
            Dictionary<string, string> data = new() {
                { "username", username },
                { "password", password }
            };

            // Getting an API response
            APILoginResponse loginResponse = await this.controller.PostLogIn("user/login", data);

            // Switch on the response code
            switch (loginResponse.Code) {
                case (0): { // Code 0 = No connection to server probably a client error but could be server invalid
                    // Inform the user about the issue
                    MessageBox.Show(this, "No connection! Please ensure you have internet connection if the problem persists please inform us.", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    // Break out of case
                    break;
                }

                case 200: { // Code 200 = All is good
                    // Welcome Messagebox
                    MessageBox.Show(this, $"Welcome {loginResponse.User.FirstName} {loginResponse.User.LastName}!", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
                    // Check if user is admin
                    if (loginResponse.User.IsAdmin) {
                        // Create admin window
                        AdminWindow awin = new(loginResponse.User);
                        // Show admin window
                        awin.Show();
                    } else { // Else for if the user is not an admin
                        // Create a user window
                        UserWindow uwin = new (loginResponse.User);
                        // Show the user window
                        uwin.Show();
                    }

                    // Close this current window
                    this.Close();
                    // Break out of case
                    break;
                }

                case 401: { // Code 401 = is a login failed request
                    // Tell the user about incorrect details
                    MessageBox.Show(this, "Username or Password Incorrect", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                    // Break out of case
                    break;
                }

                case 500: { // Code 500 = server error, needs to be reported ASAP
                    // Tell the user there is a server error
                    MessageBox.Show(this, "Internal Server error\nPlease report This Error as soon as possible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    // Break out of case
                    break;
                }
            }
        }
    }
}