using HotelManagementSystem.Services;
using System.Windows;

namespace HotelManagementSystem.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(string startPage)
        {
            InitializeComponent();

            GreetingText.Text = AuthService.GetGreeting();

            NavigateToPage(startPage);
        }

        public void NavigateToPage(string pageName)
        {
            switch (pageName)
            {
                case "UnderConstructionView":
                    MainFrame.Navigate(new UnderConstructionView());
                    break;
                case "ReceptionistView":
                    MainFrame.Navigate(new ReceptionistView());
                    break;
                default:
                    MainFrame.Navigate(new UnderConstructionView());
                    break;
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            AuthService.Logout();

            var loginWindow = new LoginWindow();
            loginWindow.Show();

            this.Close();
        }
    }
}