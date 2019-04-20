using System;
using timesheet.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace timesheet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageLogin : ContentPage
    {
        public HomePageLogin()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new Users
            {
                Mail = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                string name = usernameEntry.Text;
                App.IsUserLoggedIn = true;
                await DisplayAlert("Your Logged as", $"name", "OK");
                Navigation.InsertPageBefore(new DashBoardPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(Users user)
        {
            return user.Mail == "andrea.londero" && user.Password == "aryonsolutions";
        }
    }
}