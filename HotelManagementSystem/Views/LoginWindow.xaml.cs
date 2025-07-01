using HotelManagementSystem.Services;
using System.Windows;

namespace HotelManagementSystem.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowErrorMessage("Введите имя пользователя и пароль");
                return;
            }

            bool isAuthenticated = AuthService.Login(username, password);

            if (isAuthenticated)
            {
                var currentUser = AuthService.CurrentUser;

                if (currentUser.PositionID == 1)
                {
                    var mainWindow = new MainWindow("UnderConstructionView");
                    mainWindow.Show();
                }
                else if (currentUser.PositionID == 2)
                {
                    var mainWindow = new MainWindow("ReceptionistView");
                    mainWindow.Show();
                }

                this.Close();
            }
            else
            {
                ShowErrorMessage("Неверное имя пользователя или пароль");
            }
        }

        private void ShowErrorMessage(string message)
        {
            ErrorMessage.Text = message;
            ErrorMessage.Visibility = Visibility.Visible;
        }
    }
}